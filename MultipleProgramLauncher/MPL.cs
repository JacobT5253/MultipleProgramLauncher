using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using IWshRuntimeLibrary;

namespace MultipleProgramLauncher
{
    public partial class MPL : Form
    {
        // new implementation with the program class
        List<CustomProgram> programs = new List<CustomProgram>();
        List<Profile> profiles;

        public MPL()
        {
            InitializeComponent();
            profiles = LoadProfiles(); // load the profiles from the .csv files
            Debug.WriteLine("Profiles have been loaded");
            printProfiles();
            DisplayProfilesInUI();
            Debug.WriteLine("Profiles Should be displayed");
            this.MinimumSize = new Size(760, 490);
        }

        // When the create button is clicked
        private void CreateNewBatch_Click(object sender, EventArgs e)
        {
            Home_Panel.Hide();
            CreateBatch_Panel.Show();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Button removeButton = (Button)sender;
            int indexToRemove = (int)removeButton.Tag;

            Debug.WriteLine($"\nRemove Button clicked for indexToRemove {indexToRemove}");
            Debug.WriteLine("SelectedFiles before removing:");
            
            printProgramsArray(); // will print out the programs array with each program path, delay, and bool

            // Remove the corresponding filePathPanel from the TablePanel
            Control[] filePathPanels = Middle_Create_Flow_Panel.Controls.Find("FilePathPanel" + indexToRemove, false);

            if (filePathPanels.Length > 0)
            {
                Debug.WriteLine($"NumPanels before = {filePathPanels.Length}");
                Control filePathPanel = filePathPanels[0];
                Middle_Create_Flow_Panel.Controls.Remove(filePathPanel);
                filePathPanel.Dispose();
                Debug.WriteLine($"NumPanels after = {filePathPanels.Length}");
            }

            // Remove the file path and delay from the arrays
            programs.RemoveAt(indexToRemove);

            Debug.WriteLine("\nSelectedFiles after removing:");
            printProgramsArray(); // print all the programs after removing, to make sure the correct one is removed

            // Update the Tag property of the remove buttons and delay text boxes
            AdjustPanels(indexToRemove);
            //DisplayFilePathsInTable();
        }

        private void printProgramsArray()
        {
            for (int i = 0; i < programs.Count; i++)
            {
                // Split the path into two parts using the last "\" character as the delimiter
                int lastBackslashIndex = programs[i].Path.LastIndexOf('\\');
                Debug.WriteLine($"{programs[i].Path.Substring(lastBackslashIndex + 1)} delay: {programs[i].Delay} isAdmin: {programs[i].IsAdmin}");
            }
        }

        private void AdjustPanels(int indexToRemove)
        {
            // Find all the filePathPanels in the TablePanel
            Control[] filePathPanels = Middle_Create_Flow_Panel.Controls.OfType<Panel>().ToArray();
            Debug.WriteLine($"num of panels: {filePathPanels.Length}");
            for (int i = 0; i < filePathPanels.Length; i++)
            {
                int cur = (int)filePathPanels[i].Tag;
                Debug.WriteLine($"Current index = {cur}");


                //now that we have all the attributes we want to work with. we can now edit them if they are at an index that is larger than the index of removal
                if (cur > indexToRemove)
                {
                    Debug.WriteLine("OLD panel:");

                    // if the tag is greater than the index, print out the labels and their buttons and stuff
                    Debug.WriteLine($"panel: {filePathPanels[i].Name} tag: {filePathPanels[i].Tag}");
                    //update the tag and Name for the panel
                    filePathPanels[i].Tag = cur - 1;
                    filePathPanels[i].Name = "FilePathPanel" + (cur - 1);


                    //Update the name and tag of the button in the panel
                    Control[] removeButtons = filePathPanels[i].Controls.OfType<Button>().ToArray();
                    if (removeButtons.Length > 0)
                    {
                        Button removeButton = (Button)removeButtons[0];
                        Debug.WriteLine($"button: {removeButton.Name} tag: {removeButton.Tag}");
                        removeButton.Tag = cur - 1; // update the tag for the button
                        removeButton.Name = "RemoveButton" + (cur - 1);
                    }

                    //update the name and tag of the text box
                    Control[] delayTextBoxes = filePathPanels[i].Controls.OfType<TextBox>().ToArray();
                    if (delayTextBoxes.Length > 0)
                    {
                        TextBox delayTextBox = (TextBox)delayTextBoxes[0];
                        Debug.WriteLine($"delay: {delayTextBox.Name} tag: {delayTextBox.Tag}");
                        delayTextBox.Tag = cur - 1; //update the tag for the textbox
                        delayTextBox.Name = "DelayTextBox" + (cur - 1);
                    }
                    Control[] filePathLabels = filePathPanels[i].Controls.OfType<Label>().ToArray();
                    if (filePathLabels.Length > 0)
                    {
                        Label textLabel = (Label)filePathLabels[0];
                        Debug.WriteLine($"text: {textLabel.Name} tag: {textLabel.Tag}");
                        textLabel.Tag = cur - 1; //update the tag for the label and update its text
                        Debug.WriteLine($"i = {i}");
                        textLabel.Text = $"{programs[i].Path} + {filePathPanels[i].Tag}";
                        textLabel.Name = "DelayLabel" + (cur - 1);
                    }



                    Debug.WriteLine("\nadjusted panel:");
                    Debug.WriteLine($"panel: {filePathPanels[i].Name} tag: {filePathPanels[i].Tag}");

                    // get the button and other attributes of the panel they will be index 0 because there are only 1 of each.
                    if (removeButtons.Length > 0)
                    {
                        Button removeButton = (Button)removeButtons[0];
                        Debug.WriteLine($"button: {removeButton.Name} tag: {removeButton.Tag}");
                    }
                    if (delayTextBoxes.Length > 0)
                    {
                        TextBox delayTextBox = (TextBox)delayTextBoxes[0];
                        Debug.WriteLine($"delay: {delayTextBox.Name} tag: {delayTextBox.Tag}");
                    }
                    if (filePathLabels.Length > 0)
                    {
                        Label textLabel = (Label)filePathLabels[0];
                        Debug.WriteLine($"text: {textLabel.Name} tag: {textLabel.Tag}");
                    }
                    Debug.Write("\n\n");
                }

            }
        }
        private void AddExeFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // fixed
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
            openFileDialog.Title = "Select Executable Files";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file paths
                string[] selectedFilePaths = openFileDialog.FileNames;

                foreach (string pathToAdd in selectedFilePaths)
                {
                    if (!programs.Any(p => p.Path == pathToAdd))
                    {
                        programs.Add(new CustomProgram
                        {
                            Path = pathToAdd,
                            Delay = 0,
                            IsAdmin = false
                        });
                    }
                    else
                    {
                        MessageBox.Show($"Program {pathToAdd} already in the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                Debug.WriteLine($"{programs.Count} programs");
                Debug.WriteLine("Programs:");
                foreach (CustomProgram program in programs)
                {
                    Debug.WriteLine($"Path: {program.Path}, Delay: {program.Delay}, Is Admin: {program.IsAdmin}");
                }

                // Display the file paths in the CreateBatchPanel
                DisplayFilePathsInTable();
            }
        }


        private void DisplayFilePathsInTable()
        {
            // Clear the CreateBatchPanel before displaying the file paths
            Middle_Create_Flow_Panel.Controls.Clear();

            // Iterate through the selected file paths and display each as a row
            for (int i = 0; i < programs.Count; i++)
            {

                Panel filePathPanel = new Panel();
                filePathPanel.Name = "FilePathPanel" + i; // Set a unique name for each Panel
                //filePathPanel.Dock = DockStyle.Top;
                filePathPanel.Size = new Size(1033, 100);
                filePathPanel.Tag = i;

                // Create a Label for the file path
                Label filePathLabel = new Label();
                filePathLabel.Name = "FilePathLabel" + i;
                filePathLabel.Text = $"{programs[i].Path} + {filePathPanel.Tag}";
                filePathLabel.AutoSize = true;
                filePathLabel.Location = new Point(10, 10);
                filePathLabel.Tag = i;

                // Create a Button to remove the file path
                Button removeButton = new Button();
                removeButton.Text = "Remove";
                removeButton.Name = "RemoveButton" + i; // Set a unique name for each Button
                removeButton.Size = new Size(100, 30);
                removeButton.Location = new Point(10, filePathLabel.Bottom + 5); // Below the file path Label
                removeButton.Click += RemoveButton_Click;
                removeButton.Tag = i;

                // Create a Label for the program delay
                Label delayLabel = new Label();
                delayLabel.Text = "Delay in ms for next program:";
                delayLabel.Name = "DelayLabel" + i;
                delayLabel.AutoSize = true;
                delayLabel.Location = new Point(removeButton.Right + 10, removeButton.Top + 5); // To the right of the remove button

                // Create a TextBox for the program delay input
                TextBox delayTextBox = new TextBox();
                delayTextBox.Width = 100;
                delayTextBox.Name = "DelayTextBox" + i; // Set a unique name for each TextBox
                delayTextBox.Text = "0"; // Set the default value to "0"
                delayTextBox.Size = new Size(70, 20);
                delayTextBox.Tag = i;
                delayTextBox.Location = new Point(delayLabel.Right + 110, removeButton.Top); // To the right of the delay Label
                delayTextBox.TextChanged += DelayTextBox_TextChanged; // Add event handler for delay changes


                // Add the Label, TextBox, and Remove Button to the filePathPanel
                filePathPanel.Controls.Add(filePathLabel);
                filePathPanel.Controls.Add(removeButton);
                filePathPanel.Controls.Add(delayLabel);
                filePathPanel.Controls.Add(delayTextBox);

                // Add the filePathPanel to the CreateBatchPanel
                Middle_Create_Flow_Panel.Controls.Add(filePathPanel);
                //CreateBatchPanel.Controls.Add(filePathPanel);
            }

        }

        private void DisplayProfilesInUI()
        {
            // Clear the existing panels in the FlowLayoutPanel
            ProgramLauncher_Flow_Panel.Controls.Clear();

            // Iterate through the 'profiles' list and create panels for each profile
            for (int i = 0; i < profiles.Count; i++)
            {
                // Create a panel for this profile
                Panel profilePanel = new Panel();
                //profilePanel.BorderStyle = BorderStyle.FixedSingle;
                profilePanel.Size = new Size(1033, 100);
                profilePanel.Name = "ProfilePanel" + i; // Set a unique name for each Panel
                profilePanel.Tag = i;


                // Create a label to display the profile name
                Label nameLabel = new Label();
                nameLabel.Text = profiles[i].Name;
                nameLabel.AutoSize = true;
                nameLabel.Location = new Point(10, 10);
                nameLabel.Tag = i;  

                // Create a button to remove the profile (you can customize this part)
                Button removeButton = new Button();
                removeButton.Text = "Remove";
                removeButton.Size = new Size(100, 30);
                removeButton.Location = new Point(10, nameLabel.Bottom + 5); ;
                removeButton.Tag = i;

                Button editButton = new Button();
                editButton.Text = "Edit";
                editButton.Size = new Size(100, 30);
                editButton.Location = new Point(150, nameLabel.Bottom + 5);
                editButton.Tag = i;

                Button launchProgramsButton = new Button();
                launchProgramsButton.Text = "Launch";
                launchProgramsButton.Size = new Size(100, 30);
                launchProgramsButton.Location = new Point(500, nameLabel.Bottom + 5);
                launchProgramsButton.Tag = i;

                // Attach a Click event handler for the remove button
                removeButton.Click += (sender, e) =>
                {
                    // Handle the removal of the profile here
                    // You can access the 'profile' object associated with this panel
                    // using the Tag property or any other method you prefer
                };

                // Add the label and remove button to the profile panel
                profilePanel.Controls.Add(nameLabel);
                profilePanel.Controls.Add(removeButton);
                profilePanel.Controls.Add(editButton);
                profilePanel.Controls.Add(launchProgramsButton);
                profilePanel.Controls.Add(launchProgramsButton);
                // Add the profile panel to the FlowLayoutPanel
                ProgramLauncher_Flow_Panel.Controls.Add(profilePanel);
            }
        }

        private void printProfiles()
        {
            foreach (var profile in profiles)
            {
                Debug.WriteLine($"{profile.Name}");
            }
        }

        private void DelayTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox delayTextBox = (TextBox)sender;
            int indexToUpdate = (int)delayTextBox.Tag;

            // Update the delay value in the programDelays list when the user changes the TextBox
            int delayMilliseconds;
            if (int.TryParse(delayTextBox.Text, out delayMilliseconds))
            {
                programs[indexToUpdate].Delay = delayMilliseconds;
            }
        }



        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (programs.Count == 0)
            {
                MessageBox.Show("Please add programs to the list before exporting.");
                return;
            }

            try
            {
                string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName).FullName).FullName;
                string userCreatedFilesPath = Path.Combine(projectDirectory, "UserCreatedFiles");

                // Create the UserCreatedFiles folder if it doesn't exist
                if (!Directory.Exists(userCreatedFilesPath))
                    Directory.CreateDirectory(userCreatedFilesPath);

                // Create a SaveFileDialog to let the user choose the CSV file name and location
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveFileDialog.Title = "Export Profile";
                saveFileDialog.InitialDirectory = userCreatedFilesPath;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string csvFilePath = saveFileDialog.FileName;

                    using (var writer = new StreamWriter(csvFilePath))
                    using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        // Manually write the CSV header
                        csv.WriteField("Program Path");
                        csv.WriteField("Delay (ms)");
                        csv.WriteField("Is Admin");
                        csv.NextRecord();

                        // Write each program to the CSV file
                        foreach (var program in programs)
                        {
                            csv.WriteField(program.Path);
                            csv.WriteField(program.Delay);
                            csv.WriteField(program.IsAdmin);
                            csv.NextRecord();
                        }
                    }

                    // Create a new profile with the exported programs
                    Profile newProfile = new Profile
                    {
                        Name = Path.GetFileNameWithoutExtension(csvFilePath),
                        programs = programs.ToList() // Copy the programs to avoid modifying the original list
                    };

                    // Add the new profile to the profiles array
                    profiles.Add(newProfile);

                    // Save the updated profile order
                    SaveProfileOrder(profiles);

                    MessageBox.Show("Profile exported successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }







        private void CreateShortcut(string batchFilePath)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string shortcutPath = Path.Combine(desktopPath, Path.GetFileNameWithoutExtension(batchFilePath) + " shortcut.lnk");

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = batchFilePath;
            shortcut.Save();
        }


        private void print(object stuffToPrint)
        {
            Debug.WriteLine(stuffToPrint);
        }

        private void AddPathButton_Click(object sender, EventArgs e)
        {
            string pathToAdd = PathTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(pathToAdd) && System.IO.File.Exists(pathToAdd))
            {
                // Check if the program already exists in the list
                if (programs.Any(program => program.Path == pathToAdd))
                {
                    MessageBox.Show($"Program {pathToAdd} already in the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Add the program to the list
                    programs.Add(new CustomProgram
                    {
                        Path = pathToAdd,
                        Delay = 0,
                        IsAdmin = false
                    });

                    // Display the file paths in the CreateBatchPanel
                    DisplayFilePathsInTable();

                    PathTextBox.Clear();

                    Debug.WriteLine($"Programs count: {programs.Count}");

                    Debug.WriteLine("Programs:");
                    foreach (var program in programs)
                    {
                        Debug.Write($"{Path.GetFileName(program.Path)} ");
                    }

                    Debug.Write("\n");
                }
            }
            else
            {
                MessageBox.Show("Invalid path or path does not exist.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            CreateBatch_Panel.Hide();
            Home_Panel.Show();
            DisplayProfilesInUI();
            programs.Clear();  // Clear the programs list instead of selectedFiles and programDelays
            Middle_Create_Flow_Panel.Controls.Clear();
        }




        private void CreateProfile_Button_Click(object sender, EventArgs e)
        {
            CreateBatch_Panel.Show();
            Home_Panel.Hide();
        }


        private List<Profile> LoadProfiles()
        {
            string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName).FullName).FullName;
            string userCreatedFilesPath = Path.Combine(projectDirectory, "UserCreatedFiles");

            List<Profile> profiles = new List<Profile>();

            // Load the profile order
            List<string> profileOrder = LoadProfileOrder();

            // Check if the UserCreatedFiles folder exists
            if (Directory.Exists(userCreatedFilesPath))
            {
                // Iterate through the profile order and load profiles accordingly
                foreach (string profileName in profileOrder)
                {
                    string csvFile = Path.Combine(userCreatedFilesPath, profileName + ".csv");

                    if (System.IO.File.Exists(csvFile))
                    {
                        // Create a new Profile object
                        Profile profile = new Profile
                        {
                            Name = profileName,
                            programs = new List<CustomProgram>()
                        };

                        using (var reader = new StreamReader(csvFile))
                        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
                        {
                            // Skip the header line if it exists
                            csv.Read();

                            while (csv.Read())
                            {
                                string name = csv.GetField<string>(0);     // Assuming the name is in the first column
                                int delay = csv.GetField<int>(1);           // Assuming the delay is in the second column
                                bool isAdmin = csv.GetField<bool>(2);       // Assuming isAdmin is in the third column

                                // Create a new CustomProgram and add it to the profile's programs list
                                CustomProgram program = new CustomProgram
                                {
                                    Path = name,
                                    Delay = delay,
                                    IsAdmin = isAdmin
                                };

                                profile.programs.Add(program);
                            }
                        }

                        profiles.Add(profile);
                    }
                }
            }

            return profiles;
        }


        private void SaveProfileOrder(List<Profile> profiles)
        {
            try
            {
                string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName).FullName).FullName;
                string userCreatedFilesPath = Path.Combine(projectDirectory, "UserCreatedFiles");
                string profileOrderFilePath = Path.Combine(userCreatedFilesPath, "ProfileOrder.csv");

                using (var writer = new StreamWriter(profileOrderFilePath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    // Write the profile names to the CSV file
                    foreach (var profile in profiles)
                    {
                        csv.WriteField(profile.Name);
                        csv.NextRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the profile order: " + ex.Message);
            }
        }


        private List<string> LoadProfileOrder()
        {
            string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName).FullName).FullName;
            string profileOrderPath = Path.Combine(projectDirectory, "UserCreatedFiles", "ProfileOrder.csv");

            List<string> profileOrder = new List<string>();

            if (System.IO.File.Exists(profileOrderPath))
            {
                using (var reader = new StreamReader(profileOrderPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        profileOrder.Add(line);
                    }
                }
            }

            return profileOrder;
        }



    }


}