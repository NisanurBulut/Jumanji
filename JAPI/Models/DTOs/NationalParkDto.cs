using System;

namespace JAPI.Models.Dtos
{
    public class NationalParkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
