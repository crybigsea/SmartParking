using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Prism.Navigation.Regions;
using SmartParking.Common.ViewModels;
using SmartParking.DashboardModule.Models;
using System.Collections.ObjectModel;
using Unity;

namespace SmartParking.DashboardModule.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public ObservableCollection<BoardModel> BoardList { get; set; } = new ObservableCollection<BoardModel>();
        public ObservableCollection<AreaModel> AreaList { get; set; } = new ObservableCollection<AreaModel>();

        public ObservableCollection<RecordModel> RecordList { get; set; } = new ObservableCollection<RecordModel>();

        public SeriesCollection series { get; set; } = new SeriesCollection();

        public DashboardViewModel(IUnityContainer unityContainer, IRegionManager regionManager)
            : base(unityContainer, regionManager)
        {
            PageTitle = "Dashboard";
            CanClose = false;

            BoardList.Add(new BoardModel { Header = "总收入", Value = 568768, Color = "#EC9606", Icon = "\ue606" });
            BoardList.Add(new BoardModel { Header = "优惠卷(张)", Value = 24, Color = "#088DF6", Icon = "\ue606" });
            BoardList.Add(new BoardModel { Header = "会员累计人数", Value = 698, Color = "#F76E55", Icon = "\ue606" });
            BoardList.Add(new BoardModel { Header = "当前空车位", Value = 80, Color = "#0ACEB1", Icon = "\ue606" });
            BoardList.Add(new BoardModel { Header = "访客未处理(人)", Value = 5, Color = "#954AF2", Icon = "\ue606" });

            RecordList.Add(new RecordModel { CarImage = "/SmartParking.Assets;component/covers/huA.jpg", PlateNumber = "鄂A25630", Info = "123" });
            RecordList.Add(new RecordModel { CarImage = "/SmartParking.Assets;component/covers/wanF.jpg", PlateNumber = "鄂A25631", Info = "123" });
            RecordList.Add(new RecordModel { CarImage = "/SmartParking.Assets;component/covers/yiB.jpg", PlateNumber = "鄂A25632", Info = "123" });
            RecordList.Add(new RecordModel { CarImage = "/SmartParking.Assets;component/covers/yueA.jpg", PlateNumber = "鄂A25633", Info = "123" });

            series.Add(new PieSeries
            {
                Title = "微信支付",
                Values = new ChartValues<ObservableValue> { new ObservableValue(16.0) }
            });
            series.Add(new PieSeries
            {
                Title = "支付宝支付",
                Values = new ChartValues<ObservableValue> { new ObservableValue(22.0) }
            });
            series.Add(new PieSeries
            {
                Title = "现金支付",
                Values = new ChartValues<ObservableValue> { new ObservableValue(11.0) }
            });
            series.Add(new PieSeries
            {
                Title = "优惠减免",
                Values = new ChartValues<ObservableValue> { new ObservableValue(39.0) }
            });
            series.Add(new PieSeries
            {
                Title = "会员",
                Values = new ChartValues<ObservableValue> { new ObservableValue(12.0) }
            });
        }
    }
}
