using Prism.Regions;
using Prism.Services.Dialogs;
using SmartParking.Client;
using SmartParking.Client.Dtos.SysUpdateInfo;
using SmartParking.Common;
using SmartParking.Common.ViewModels;
using SmartParking.SystemModule.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Threading;
using Unity;

namespace SmartParking.SystemModule.ViewModels
{
    public class FileUploadViewModel : ViewModelBase
    {
        private readonly IUpdateFileService _updateFileService;
        private readonly IUnityContainer _unityContainer;
        private readonly IDialogService _dialogService;
        private readonly IRegionManager _regionManager;
        private readonly GlobalInfo _globalInfo;

        //public ObservableCollection<UpdateFileModel> updateFileModels = new ObservableCollection<UpdateFileModel>();//不能是字段，必须是属性
        public ObservableCollection<UpdateFileModel> updateFileModels { get; set; } = new ObservableCollection<UpdateFileModel>();

        public FileUploadViewModel(IUpdateFileService updateFileService,
            IUnityContainer unityContainer, IDialogService dialogService,
            IRegionManager regionManager, GlobalInfo globalInfo) : base(unityContainer, regionManager)
        {
            PageTitle = "文件上传";
            AddButtonText = "上传";
            _updateFileService = updateFileService;
            _unityContainer = unityContainer;
            _dialogService = dialogService;
            _regionManager = regionManager;
            _globalInfo = globalInfo;
        }

        public override void Refresh()
        {
            Task.Run(async () =>
            {
                var files = (await _updateFileService.GetPagedFiles($"Bearer {_globalInfo.LoginUserInfo?.Token}", new SysUpdateFilePagedResultRequestDto
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
        }

        public override void Add()
        {
            _dialogService.ShowDialog("AddFileDialog");
        }
    }
}
