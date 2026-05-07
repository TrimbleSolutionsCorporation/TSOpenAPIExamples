namespace ModelSharingAPIExample
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Security.Policy;
    using System.Text;
    using System.Windows.Input;

    using Tekla.Structures.Model;
    using Tekla.Structures.ModelInternal;

    using Task = System.Threading.Tasks.Task;

    /// <summary>
    /// Demo feature view model.
    /// </summary>
    class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the value of a property and raises PropertyChanged if the value changed.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">The backing field.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>True if the value changed; otherwise, false.</returns>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private string output;

        private bool runInWorkerThread = false;

        private bool showProgressDialog = false;

        private string newUserEmail = string.Empty;

        private SharingRole newUserRole = SharingRole.Viewer;

        private bool newUserSendEmail = false;

        private string newUserCustomMessage = string.Empty;

        private string inviteModelId = string.Empty;

        private string newModelCode = string.Empty;

        private string newModelDescription = string.Empty;

        private ISharingLocation newModelLocation = null;

        private string modelToExclude = string.Empty;

        private string modelIdToRemove = string.Empty;

        private string modelIdToGetUpdates = string.Empty;

        private string joinPath = string.Empty;

        private string modelIdToJoin = string.Empty;

        private string updateIdToJoin = string.Empty;

        private bool watchEvents = false;

        private ISharingEvents sharingEvents = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            TestSharingOperationAsyncCommand = new RelayCommand(() => TestSharingOperationAsync());
            FakeResult1Command = new RelayCommand(() => FakeResult1());
            InviteUserAsyncCommand = new RelayCommand(() => InviteUserAsync());
            StartSharingAsyncCommand = new RelayCommand(() => StartSharingAsync());
            WriteOutAsyncCommand = new RelayCommand(() => WriteOutAsync());
            CreateBaselineAsyncCommand = new RelayCommand(() => CreateBaselineAsync());
            ExcludeFromSharingAsyncCommand = new RelayCommand(() => ExcludeFromSharingAsync());
            RemoveModelAsyncCommand = new RelayCommand(() => RemoveModelAsync());
            GetLocationsAsyncCommand = new RelayCommand(() => GetLocationsAsync());
            GetModelsAsyncCommand = new RelayCommand(() => GetModelsAsync());
            GetUpdatesAsyncCommand = new RelayCommand(() => GetUpdatesAsync());
            JoinAsyncCommand = new RelayCommand(() => JoinAsync());
            ReadInAsyncCommand = new RelayCommand(() => ReadInAsync());
            SetJonPathCommand = new RelayCommand(() => SetJonPath());
            ClearOutputCommand = new RelayCommand(() => ClearOutput());
        }

        /// <summary>
        /// Gets the command to test sharing operation.
        /// </summary>
        public ICommand TestSharingOperationAsyncCommand { get; }

        /// <summary>
        /// Gets the command to fake result 1.
        /// </summary>
        public ICommand FakeResult1Command { get; }

        /// <summary>
        /// Gets the command to invite user.
        /// </summary>
        public ICommand InviteUserAsyncCommand { get; }

        /// <summary>
        /// Gets the command to start sharing.
        /// </summary>
        public ICommand StartSharingAsyncCommand { get; }

        /// <summary>
        /// Gets the command to write out.
        /// </summary>
        public ICommand WriteOutAsyncCommand { get; }

        /// <summary>
        /// Gets the command to create baseline.
        /// </summary>
        public ICommand CreateBaselineAsyncCommand { get; }

        /// <summary>
        /// Gets the command to exclude from sharing.
        /// </summary>
        public ICommand ExcludeFromSharingAsyncCommand { get; }

        /// <summary>
        /// Gets the command to remove model.
        /// </summary>
        public ICommand RemoveModelAsyncCommand { get; }

        /// <summary>
        /// Gets the command to get locations.
        /// </summary>
        public ICommand GetLocationsAsyncCommand { get; }

        /// <summary>
        /// Gets the command to get models.
        /// </summary>
        public ICommand GetModelsAsyncCommand { get; }

        /// <summary>
        /// Gets the command to get updates.
        /// </summary>
        public ICommand GetUpdatesAsyncCommand { get; }

        /// <summary>
        /// Gets the command to join.
        /// </summary>
        public ICommand JoinAsyncCommand { get; }

        /// <summary>
        /// Gets the command to read in.
        /// </summary>
        public ICommand ReadInAsyncCommand { get; }

        /// <summary>
        /// Gets the command to set join path.
        /// </summary>
        public ICommand SetJonPathCommand { get; }

        /// <summary>
        /// Gets the command to clear output.
        /// </summary>
        public ICommand ClearOutputCommand { get; }

        /// <summary>
        /// Gets or sets the content of output control.
        /// </summary>
        public string Output
        {
            get { return this.output; }
            set { this.SetValue(ref this.output, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to run the operation in a worker thread.
        /// </summary>
        public bool RunInWorkerThread
        {
            get { return this.runInWorkerThread; }
            set { this.SetValue(ref this.runInWorkerThread, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show a model progress dialog during the operation.
        /// </summary>
        public bool ShowProgressDialog
        {
            get { return this.showProgressDialog; }
            set { this.SetValue(ref this.showProgressDialog, value); }
        }

        /// <summary>
        /// Gets or sets the email of the new user to invite to the model.
        /// </summary>
        public string NewUserEmail
        {
            get { return this.newUserEmail; }
            set { this.SetValue(ref this.newUserEmail, value); }
        }

        /// <summary>
        /// Gets or sets the role of the new user to invite to the model.
        /// </summary>
        public SharingRole NewUserRole
        {
            get { return this.newUserRole; }
            set { this.SetValue(ref this.newUserRole, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to send an email to the new user.
        /// </summary>
        public bool NewUserSendEmail
        {
            get { return this.newUserSendEmail; }
            set { this.SetValue(ref this.newUserSendEmail, value); }
        }

        /// <summary>
        /// Gets or sets a custom message to include in the invitation.
        /// </summary>
        public string NewUserCustomMessage
        {
            get { return this.newUserCustomMessage; }
            set { this.SetValue(ref this.newUserCustomMessage, value); }
        }

        /// <summary>
        /// Get the available sharing locations for models.
        /// </summary>
        public ObservableCollection<ISharingLocation> AvailableLocations { get; } = new ObservableCollection<ISharingLocation>();

        /// <summary>
        /// Gets or sets guid of the model to invite user to.
        /// </summary>
        public string InviteModelId
        {
            get { return this.inviteModelId; }
            set { this.SetValue(ref this.inviteModelId, value); }
        }

        /// <summary>
        /// Gets or sets the model code for start sharing.
        /// </summary>
        public string NewModelCode
        { 
            get { return this.newModelCode; }
            set { this.SetValue(ref this.newModelCode, value); }
        }

        /// <summary>
        /// Gets or sets the model description for start sharing.
        /// </summary>
        public string NewModelDescription
        {
            get { return this.newModelDescription; }
            set { this.SetValue(ref this.newModelDescription, value); }
        }

        /// <summary>
        /// Gets or sets the model location for start sharing.
        /// </summary>
        public ISharingLocation NewModelLocation
        {
            get { return this.newModelLocation; }
            set { this.SetValue(ref this.newModelLocation, value); }
        }

        /// <summary>
        /// Gets or sets the model path to exclude from sharing.
        /// </summary>
        public string ModelToExclude
        {
            get { return this.modelToExclude; }
            set { this.SetValue(ref this.modelToExclude, value); }
        }

        /// <summary>
        /// Gets or sets the ID of the model to remove from sharing service.
        /// </summary>
        public string ModelIdToRemove
        {
            get { return this.modelIdToRemove; }
            set { this.SetValue(ref this.modelIdToRemove, value); }
        }

        /// <summary>
        /// Gets or sets the ID of the model to retrieve updates for.
        /// </summary>
        public string ModelIdToGetUpdates
        {
            get { return this.modelIdToGetUpdates; }
            set { this.SetValue(ref this.modelIdToGetUpdates, value); }
        }

        /// <summary>
        /// Gets or sets the path to join the model.
        /// </summary>
        public string JoinPath
        {
            get { return this.joinPath; }
            set { this.SetValue(ref this.joinPath, value); }
        }

        /// <summary>
        /// Gets or sets the ID of the model to join.
        /// </summary>
        public string ModelIdToJoin
        {
            get { return this.modelIdToJoin; }
            set { this.SetValue(ref this.modelIdToJoin, value); }
        }

        /// <summary>
        /// Gets or sets the update ID to join.
        /// </summary>
        public string UpdateIdToJoin
        {
            get { return this.updateIdToJoin; }

            set { this.SetValue(ref this.updateIdToJoin, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to watch shared model state changed events.
        /// </summary>
        public bool WatchEvents
        {
            get { return this.watchEvents; }
            set
            {
                try
                {
                    this.SetValue(ref this.watchEvents, value);

                    if (this.sharingEvents != null)
                    {
                        this.sharingEvents.Dispose();
                        this.sharingEvents = null;
                    }

                    if (value)
                    {
                        this.sharingEvents = new ModelSharingHandler().GetSharingEvents();
                        this.sharingEvents.SharedModelStateChanged += this.OnSharedModelStateChanged;
                    }
                }
                catch (Exception ex)
                {
                    this.AddToOutput($"Changing watching events failed: {ex}");
                }
            }
        }

        /// <summary>
        /// Invoke the <see cref="Operation.TestSharingOperationAsync(bool)"/> method and display the result in the output control.
        /// </summary>
        public async void TestSharingOperationAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        this.AddToOutput("Starting TestSharingOperationAsync...");
                        var result = await Operation.TestSharingOperationAsync(this.ShowProgressDialog);
                        this.AddToOutput($"TestSharingOperationAsync completed: ({this.ToString(result)}).");
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"TestSharingOperationAsync failed: {ex}");
                    }
                }
            );
        }

        public void FakeResult1()
        {
            var result = new SharingResult
            {
                Code = SharingResultCode.OK,
                ErrorDetails = "Foo",
                State = SharingResultState.ProcessClosed,
                NotificationsList = new[] { "bar", "baz" },
            };
            this.AddToOutput($"Fake result: {this.ToString(result)}");
        }

        public async void InviteUserAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        this.AddToOutput($"Inviting user: {this.NewUserEmail}, {this.NewUserRole}...");
                        var result = await new ModelSharingHandler().InviteUserAsync(
                            this.NewUserEmail,
                            this.NewUserRole,
                            this.NewUserSendEmail,
                            this.NewUserCustomMessage,
                            modelId: Guid.TryParse(this.InviteModelId, out var inviteModelGuid) ? inviteModelGuid : null);
                        this.AddToOutput($"Inviting user completed: ({this.ToString(result)}).");
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"InviteUserAsync failed: {ex}");
                    }
                });
        }

        public async void StartSharingAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        this.AddToOutput($"Starting model sharing: {this.NewModelCode}, {this.NewModelDescription}, {this.NewModelLocation}...");
                        var result = await new ModelSharingHandler().StartSharingAsync(
                            this.NewModelCode,
                            this.NewModelDescription,
                            this.NewModelLocation?.Id);
                        this.AddToOutput($"Starting model sharing completed: ({this.ToString(result)}).");
                        if (result.Data != null)
                        {
                            this.AddToOutput($"New model id: {result.Data}");
                        }
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"StartSharingAsync failed: {ex}");
                    }
                });
        }

        public async void WriteOutAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        this.AddToOutput($"Writing out: {this.NewModelCode}, {this.NewModelDescription}...");
                        var result = await new ModelSharingHandler().WriteOutAsync(
                            this.NewModelCode,
                            this.NewModelDescription);
                        this.AddToOutput($"Writing out completed: ({this.ToString(result)}).");
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"WriteOutAsync failed: {ex}");
                    }
                });
        }

        public async void CreateBaselineAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        this.AddToOutput($"Creating baseline: {this.NewModelCode}, {this.NewModelDescription}...");
                        var result = await new ModelSharingHandler().CreateBaselineAsync(
                            this.NewModelCode,
                            this.NewModelDescription);
                        this.AddToOutput($"Creating baseline completed: ({this.ToString(result)}).");
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"CreateBaselineAsync failed: {ex}");
                    }
                });
        }

        public async void ExcludeFromSharingAsync()
        {
            await this.RunActionWithThreading(
                () =>
                {
                    try
                    {
                        this.AddToOutput("Excluding from sharing...");
                        var modelPath = string.IsNullOrWhiteSpace(this.ModelToExclude) ? new Model().GetInfo().ModelPath : this.ModelToExclude;
                        var excludeResult = new ModelSharingHandler().ExcludeAndOpen(modelPath);
                        this.AddToOutput($"Completed: ({this.ToString(excludeResult)}");
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"Failed: {ex}");
                    }

                    return Task.CompletedTask;
                });
        }

        public async void RemoveModelAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        if (!Guid.TryParse(this.ModelIdToRemove, out var modelIdGuid))
                        {
                            this.AddToOutput($"Invalid guid: {this.ModelIdToRemove}!");
                            return;
                        }
                        this.AddToOutput($"Removing model: {this.ModelIdToRemove}...");
                        var result = await new ModelSharingHandler().RemoveModelAsync(modelIdGuid);
                        this.AddToOutput($"Removing model completed: ({this.ToString(result)}).");
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"RemoveModelAsync failed: {ex}");
                    }
                });
        }

        public async void GetLocationsAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        this.AddToOutput("Getting locations...");
                        var locationsResult = (await new ModelSharingHandler().GetLocationsAsync());
                        this.AddToOutput($"Getting locations completed: {this.ToString(locationsResult)}");
                        var notEmpty = false;
                        this.AvailableLocations.Clear();
                        foreach (var region in locationsResult.Data?.Locations ?? Enumerable.Empty<ISharingLocation>())
                        {
                            notEmpty = true;
                            this.AddToOutput($"{region.DisplayName};{region.Id};{(region.Name != region.DisplayName ? region.Name : string.Empty)}");
                            this.AvailableLocations.Add(region);
                            if (region.Id == locationsResult.Data.DefaultLocation)
                            {
                                this.NewModelLocation = region;
                            }
                        }
                        if (notEmpty)
                        {
                            this.AddToOutput("------");
                        }
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"GetRegionsAsync failed: {ex}");
                    }
                });
        }

        public async void GetModelsAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        this.AddToOutput("Getting models...");
                        var modelsResult = (await new ModelSharingHandler().GetModelsAsync());
                        this.AddToOutput($"Getting models completed: ({this.ToString(modelsResult)})");
                        var notEmpty = false;
                        foreach (var model in modelsResult.Data ?? Enumerable.Empty<SharedModel>())
                        {
                            notEmpty = true;
                            this.AddToOutput("------");
                            this.AddToOutput($"Id: {model.Id}");
                            this.AddToOutput($"Name: {model.Name}");
                            this.AddToOutput($"Code: {model.Code}");
                            this.AddToOutput($"Description: {model.Description}");
                            this.AddToOutput($"Owner: {model.Owner}");
                            this.AddToOutput($"CreatedAt: {model.CreatedAt.ToString("u", CultureInfo.InvariantCulture)}");
                            this.AddToOutput($"CurrentUserRole: {model.CurrentUserRole}");
                        }

                        if (notEmpty)
                        {
                            this.AddToOutput("------");
                        }
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"GetModelsAsync failed: {ex}");
                    }
                });
        }

        public async void GetUpdatesAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        var modelIdGuid = Guid.Empty;
                        if (!string.IsNullOrWhiteSpace(this.ModelIdToGetUpdates) && !Guid.TryParse(this.ModelIdToGetUpdates, out modelIdGuid))
                        {
                            this.AddToOutput($"Invalid guid: {this.ModelIdToGetUpdates}!");
                            return;
                        }

                        this.AddToOutput($"Getting updates for model: {this.ModelIdToGetUpdates}...");
                        var result = await new ModelSharingHandler().GetUpdatesAsync(modelIdGuid);
                        this.AddToOutput($"Getting updates completed: ({this.ToString(result)}).");
                        
                        if (result.Data != null)
                        {
                            this.AddToOutput("Updates:");
                            foreach (var update in result.Data)
                            {
                                this.AddToOutput($"- {update.Id} {update.CreatedAt.ToString("u", CultureInfo.InvariantCulture)}: {update.Type} ({update.Number}) by {update.CreatedBy}: {update.Code}, {update.Comment}");
                            }
                            this.AddToOutput("------");
                        }
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"GetUpdatesAsync failed: {ex}");
                    }
                });
        }

        public async void JoinAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        if (!Guid.TryParse(this.ModelIdToJoin, out var modelIdGuid))
                        {
                            this.AddToOutput($"Invalid model guid: {this.ModelIdToJoin}!");
                            return;
                        }

                        var updateId = Guid.Empty;
                        if (!string.IsNullOrWhiteSpace(this.UpdateIdToJoin) && !Guid.TryParse(this.UpdateIdToJoin, out updateId))
                        {
                            this.AddToOutput($"Invalid update guid: {this.UpdateIdToJoin}!");
                            return;
                        }

                        this.AddToOutput($"Joining model: {this.ModelIdToJoin} to path: {this.JoinPath} with update ID: {this.UpdateIdToJoin}...");
                        var result = await new ModelSharingHandler().JoinAsync(modelIdGuid, this.JoinPath, updateId);
                        this.AddToOutput($"Joining model completed: ({this.ToString(result)}).");
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"JoinAsync failed: {ex}");
                    }
                });
        }

        public async void ReadInAsync()
        {
            await this.RunActionWithThreading(
                async () =>
                {
                    try
                    {
                        var updateId = Guid.Empty;
                        if (!string.IsNullOrWhiteSpace(this.UpdateIdToJoin) && !Guid.TryParse(this.UpdateIdToJoin, out updateId))
                        {
                            this.AddToOutput($"Invalid update guid: {this.UpdateIdToJoin}!");
                            return;
                        }

                        this.AddToOutput($"Reading in with update ID: {this.UpdateIdToJoin}...");
                        var result = await new ModelSharingHandler().ReadInAsync(updateId);
                        this.AddToOutput($"Reading in completed: ({this.ToString(result)}).");
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput($"ReadInAsync failed: {ex}");
                    }
                });
        }

        public void SetJonPath()
        {
            try
            {
                using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                {
                    dialog.Description = "Select folder to join the model";
                    dialog.SelectedPath = this.JoinPath;
                    dialog.ShowNewFolderButton = true;

                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.JoinPath = dialog.SelectedPath;
                        this.AddToOutput($"Join path set to: {this.JoinPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                this.AddToOutput($"SetJoinPath failed: {ex}");
            }
        }
        /// <summary>
        /// Clear the output control.
        /// </summary>
        public void ClearOutput()
        {
            this.Output = string.Empty;
        }

        /// <summary>
        /// Converts result to string.
        /// </summary>
        /// <param name="result">The result.</param>
        private string ToString(ISharingResult result)
        {
            var buffer = new StringBuilder();
            buffer.Append($"Code: {result.Code}");
            if (!string.IsNullOrWhiteSpace(result.ErrorDetails))
            {
                buffer.Append($"\nErrorDetails: {result.ErrorDetails}");
            }

            if (result.State != SharingResultState.Undefined)
            {
                buffer.Append($"\nState: {result.State}");
            }

            if (!string.IsNullOrWhiteSpace(result.ErrorPath))
            {
                buffer.Append($"\nErrorPath: {result.ErrorPath}");
            }

            if (result.PathLengthLimit != 0)
            {
                buffer.Append($"\nPathLengthLimit: {result.PathLengthLimit}");
            }

            if (result.Notifications != null && result.Notifications.Any())
            {
                buffer.Append("\nNotifications:");
                foreach (var notification in result.Notifications)
                {
                    buffer.Append($"\n- {notification}");
                }
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Handles shared model state changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event data.</param>
        private void OnSharedModelStateChanged(object sender, ISharedModelState e)
        {
            this.AddToOutput($"Shared model state changed: {{ {e.State}, {e.PendingVersionsCount} versions to read }}");
        }

        /// <summary>
        /// Runs the specified action either in a worker thread or in the UI thread, depending on the <see cref="RunInWorkerThread"/> property.
        /// </summary>
        /// <param name="action">The action to run.</param>
        /// <returns>An awaitable task.</returns>
        private async Task RunActionWithThreading(Func<Task> action)
        {
            if (this.RunInWorkerThread)
            {
                await Task.Run(() => action());
            }
            else
            {
                await action();
            }
        }

        /// <summary>
        /// Thread-safe adding of text to output.
        /// </summary>
        /// <param name="text">The text to add, also adding a newline.</param>
        private void AddToOutput(string text)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() => this.Output += text + "\n");
        }
    }
}
