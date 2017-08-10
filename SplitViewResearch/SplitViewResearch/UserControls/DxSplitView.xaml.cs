using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SplitViewResearch.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DxSplitView 
    {
        private double _originalX;
        private double _delta;

        public DxSplitView()
        {
            InitializeComponent();
        }

        public View Master
        {
            get { return this.MasterContentView.Content; }
            set { MasterContentView.Content = value; }
        }

        public View Detail
        {
            get { return this.DetailContentView.Content; }
            set { DetailContentView.Content = value; }
        }

        private void PanGestureRecognizerOnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    _originalX = MainContainer.ColumnDefinitions[0].Width.Value;
                    Separator.IsVisible = true;
                    AbsoluteLayout.SetLayoutBounds(Separator, new Rectangle(_originalX + 5, 0, 5, Height));
                    break;
                case GestureStatus.Running:
                    _delta = e.TotalX;
                    AbsoluteLayout.SetLayoutBounds(Separator, new Rectangle(_originalX + 5 + e.TotalX, 0, 5, Height));
                    break;
                case GestureStatus.Completed:
                    MainContainer.ColumnDefinitions[0].Width = _originalX + _delta;
                    Separator.IsVisible = false;
                    break;
            }
        }
    }
}