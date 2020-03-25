using CinematicsXF.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinematicsXF
{
    public class TvDetailViewModel : BaseViewModel
    {
        public TvDetailViewModel(TvItem tvItem)
        {
            this.Tv = tvItem;
        }

        public TvItem Tv { get; private set; }
    }
}
