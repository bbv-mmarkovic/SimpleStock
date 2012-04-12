﻿// ------------------------------------------------------------------------------
// <copyright file="StockOverviewViewModel.cs" company="bbv Software Services AG">
//   Copyright (c) 2012
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace SimpleStock.StockOverview
{
    using System.ComponentModel;

    using SimpleStock.StockOverview.StockDetail;
    using SimpleStock.StockOverview.StockList;
    using SimpleStock.StockService;

    public class StockOverviewViewModel
    {
        private readonly IStockService stockService;
        private readonly StockListViewModel stockListViewModel;
        private readonly StockDetailViewModel stockDetailViewModel;

        public StockOverviewViewModel()
        {
        }

        public StockOverviewViewModel(IStockService stockService, StockListViewModel stockListViewModel, StockDetailViewModel stockDetailViewModel)
        {
            this.stockService = stockService;
            this.stockListViewModel = stockListViewModel;
            this.stockListViewModel.PropertyChanged += this.StockListPropertyChanged;
            this.stockDetailViewModel = stockDetailViewModel;
        }

        private void StockListPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (this.stockListViewModel.CurrentStockItem != null)
            {
                StockDetailInfo stockDetailInfo = this.stockService.GetStockDetail(this.stockListViewModel.CurrentStockItem.Id);
                this.stockDetailViewModel.SetStockDetail(stockDetailInfo);
            }
        }
    }
}