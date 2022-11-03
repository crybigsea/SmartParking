using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SmartParking.Client;
using SmartParking.Client.Dtos.SysUpdateInfo;
using SmartParking.SystemModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Unity;

namespace SmartParking.SystemModule.ViewModels
{
    public class FileUploadViewModel : BindableBase
    {
        private readonly IUpdateFileService _updateFileService;
        private readonly IUnityContainer _unityContainer;
        private readonly IDialogService _dialogService;

        //public ObservableCollection<UpdateFileModel> updateFileModels = new ObservableCollection<UpdateFileModel>();//不能是字段，必须是属性
        public ObservableCollection<UpdateFileModel> updateFileModels { get; set; } = new ObservableCollection<UpdateFileModel>();

        private string keyword;
        public string Keyword
        {
            get { return keyword; }
            set { SetProperty(ref keyword, value); }
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand AddFileCommand { get; set; }

        public FileUploadViewModel(IUpdateFileService updateFileService, IUnityContainer unityContainer, IDialogService dialogService)
        {
            _updateFileService = updateFileService;
            _unityContainer = unityContainer;
            _dialogService = dialogService;
            RefreshCommand = new DelegateCommand(() =>
            {
                Task.Run(async () =>
                {
                    var files = (await _updateFileService.GetPagedFiles(new SysUpdateFilePagedResultRequestDto
                    {
                        Keyword = Keyword,
                        SkipCount = 0,
                        MaxResultCount = 10,
                    })).items;
                    _unityContainer.Resolve<Dispatcher>().Invoke(() =>
                    {
                        updateFileModels.Clear();
                        int index = 0;
                        foreach (var file in files)
                        {
                            index++;
                            updateFileModels.Add(new UpdateFileModel
                            {
                                Index = index,
                                FileName = file.FileName,
                                FileMD5 = file.FileMD5,
                                FilePath = file.FilePath
                            });
                        }
                    });
                });
            });
            AddFileCommand = new DelegateCommand(() =>
            {
                _dialogService.ShowDialog("AddFileDialog");
            });
        }
    }
}
