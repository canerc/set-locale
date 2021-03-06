﻿using System;
using System.Collections.Generic;

namespace SetLocale.Client.Web.Entities
{
    public class PagedList<TEntity> where TEntity : BaseEntity
    {
        public int Number { get; set; }
        public int Size { get; set; }
        public long TotalCount { get; set; }
        public int TotalPageCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public List<TEntity> Items { get; set; }

        public PagedList(int pageNumber, int pageSize, long totalCount, List<TEntity> source)
        {
            Items = new List<TEntity>();
            Items.AddRange(source);

            Number = pageNumber;
            Size = pageSize;
            TotalCount = totalCount;
            TotalPageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            HasPreviousPage = Number > 1;
            HasNextPage = Number < TotalPageCount;
        }
    }
}