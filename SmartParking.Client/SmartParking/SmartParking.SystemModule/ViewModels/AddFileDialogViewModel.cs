using Microsoft.Win32;
using Prism.Commands;
using Prism.Dialogs;
using SmartParking.SystemModule.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace SmartParking.SystemModule.ViewModels
{
    internal class AddFileDialogViewModel : IDialogAware
    {
        public string Title => "文件上传";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public ObservableCollection<UpdateFileModel> FileList { get; set; } = new ObservableCollection<UpdateFileModel>();

        public ICommand SelectFileCommand { get; set; }

        DialogCloseListener IDialogAware.RequestClose => throw new NotImplementedException();

        public AddFileDialogViewModel()
        {
            SelectFileCommand = new DelegateCommand(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == true)
                {
                    FileList.Clear();
                    if (openFileDialog.FileNames != null && openFileDialog.FileNames.Any())
                    {
                        int index = 0;
                        foreach (var file in openFileDialog.FileNames)
                        {
                            index++;
                            FileList.Add(new UpdateFileModel
                            {
                                Index = index,
                                FullPath = file,
                                FileName = new FileInfo(file).Name,
                                Status = "待上传"
                            });
                        }
                    }
                }
            });
        }
    }
}
