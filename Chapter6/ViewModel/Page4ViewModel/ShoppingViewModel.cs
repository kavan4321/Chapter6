﻿using Chapter6.HttpModel.Page4HttpModel;
using Chapter6.Model;
using Chapter6.Model.Page4Model;
using Chapter6.Model.Page4Model.Model.Catogary;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page4ViewModel.ViewModelShopping;

public class ShoppingViewModel:INotifyPropertyChanged
{
    public event EventHandler<PageResult> GetCatogoryEventHandler;
    public event EventHandler<PageResult> GetProductEventHandler;
    
    private GetCatogaryModel _getCatogaryModel;
    private GetProductModel _getProductModel;
    
    private ObservableCollection<string> _catagoryDetails;
    public ObservableCollection<string> CatagoryDetails
    {
        get => _catagoryDetails;
        set
        {
            _catagoryDetails = value;
             OnPropertyChanged();
        }
    }

    private ObservableCollection<ProductDetail> _productDetails;
    public ObservableCollection<ProductDetail> ProductDetails
    {
        get => _productDetails;
        set
        {
            _productDetails= value;
            OnPropertyChanged();
        }
    }

    private string _itemSelected;
    public string ItemSelected
    {
        get
        {
            return _itemSelected;
        }
        set
        {
            if(_itemSelected != value)
            {
                _itemSelected = value;
                OnPropertyChanged();
            }
        }
    }

    private bool _isLoding;
    public bool IsLoading
    {
        get => _isLoding;
        set
        {
            _isLoding = value;
            OnPropertyChanged();
        }
    }
   
    private bool _showCollection;
    public bool ShowCollection
    {
        get => _showCollection;
        set
        {
            _showCollection = value;
            OnPropertyChanged();
        }
    }

    public Command SelectionCommand { get;private set; }

    public ShoppingViewModel()
    {
        _getCatogaryModel = new GetCatogaryModel();
        _getProductModel = new GetProductModel();
        SelectionCommand = new Command(()=> { _ = GetProductDetailAsync(); });
    }

  
    public async Task GetCatagoryDetailAsync()
    {
        
        var result=await _getCatogaryModel.GetCatogaryDetailAsync();
        CatagoryDetails = _getCatogaryModel.CatogaryDetails.ToObservableCollection();
        ItemSelected = CatagoryDetails.FirstOrDefault();
        _getProductModel.Catagory = ItemSelected;
        GetCatogoryEventHandler?.Invoke(this, result);     
    }


    public async Task GetProductDetailAsync()
    {
        IsLoading=true;
        ShowCollection=false;
        _getProductModel.Catagory = ItemSelected;
        var result = await _getProductModel.GetProduvtDetailsAsync();
        ProductDetails=_getProductModel.ProductDetails.ToObservableCollection();
        GetProductEventHandler?.Invoke(this, result);
        IsLoading = false;
        ShowCollection = true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
