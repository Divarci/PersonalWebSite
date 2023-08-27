﻿namespace EntityLayer.BlogApi.GenericResponseVM
{
    public class CustomResponseVM<T>
    {
        public T? Data { get; set; }

        public int StatusCode { get; set; }

        public List<string>? Errors { get; set; }
    }
}
