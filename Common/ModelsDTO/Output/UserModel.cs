using System;

namespace Common.ModelsDTO.Output
{
    public class UserModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string MobileNumber { get; set; }

        public byte State { get; set; }

        public string CountryName { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
