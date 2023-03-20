
using Chapter6.HttpModel.Page4HttpModel;
using Chapter6.Model;
using Chapter6.Model.Page4Model.Model.Catogary;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page4ViewModel.ViewModelShopping;

public class ShoppingViewModel:INotifyPropertyChanged
{
    public event EventHandler<PageResult> GetEventHandler; 
    private GetCatogaryModel _getCatogaryModel;
    private ObservableCollection<ShoppingResponceModel> _shoppingResponceModels;
    public ObservableCollection<ShoppingResponceModel> CatagoryDetails
    {
        get => _shoppingResponceModels;
        set
        {
            _shoppingResponceModels = value;

        }
    }



    public ShoppingViewModel()
    {
        _getCatogaryModel = new GetCatogaryModel();
    }


    public async Task GetCatagoryDetailAsync()
    {
        var result=await _getCatogaryModel.GetCatogaryDetailAsync();
        CatagoryDetails = _getCatogaryModel.CatogaryDetails.ToObservableCollection();
        GetEventHandler?.Invoke(this, result);
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
