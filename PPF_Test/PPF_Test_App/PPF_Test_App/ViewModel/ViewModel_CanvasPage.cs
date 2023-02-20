using PPF_Test_App.Model;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace PPF_Test_App.ViewModel;

internal class ViewModel_CanvasPage : ObservableObject
{
    private Model_UserData V_UserData;
    public string V_name
    {
        get => V_UserData.V_Name;
        set
        {
            V_UserData.V_Name = value;
            OnPropertyChanged();
        }
    }
    public int V_remainingDays
    {
        get => V_UserData.V_Remainingdays;
        set
        {
            V_UserData.V_Remainingdays = value;
            OnPropertyChanged();
        }
    }
    public string V_macAddress
    {
        get => V_UserData.V_MacAddress;
        set
        {
            V_UserData.V_MacAddress = value;
            OnPropertyChanged();
        }
    }
    public float V_area
    {
        get => V_UserData.V_Credit.V_Area;
        set
        {
            V_UserData.V_Credit.V_Area = value;
            OnPropertyChanged();
        }
    }
    public int V_times
    {
        get => V_UserData.V_Credit.V_Times;
        set
        {
            V_UserData.V_Credit.V_Times = value;
        }
    }
}