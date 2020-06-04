﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmModular.Models
{
    public class Watch
    {
        private decimal price;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WatchImagePath { get; set; }
        public decimal Price 
        { 
            get 
            {
                decimal additionalVal = this.price;
                this.WatchParts.ForEach(item => 
                {
                    additionalVal += item.TextureMap.TexturePrice;
                });
                return additionalVal;
            }
            set { this.price = Price; }
        }
        public List<WatchPart> WatchParts { get; set; } = new List<WatchPart>();
        public List<WatchComponents> WatchComponents { get; set; } = new List<WatchComponents>();

        public Watch()
        {
        }

        public void AddComponent(WatchPart part)
        {
            this.WatchParts.Add(part);
        }
    }
}
