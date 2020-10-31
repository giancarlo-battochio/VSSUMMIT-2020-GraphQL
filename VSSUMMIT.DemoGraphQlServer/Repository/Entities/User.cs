using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VSSUMMIT.Demo00
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
