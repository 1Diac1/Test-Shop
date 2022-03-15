using System;

namespace Test_Shop.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now.ToString("G");
        }
    }
}
