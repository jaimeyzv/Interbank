using NPoco;
using System;
using System.ComponentModel.DataAnnotations;

namespace Intercorp.Dtos
{
    [TableName("Client")]
    [PrimaryKey("ClientId")]
    public class ClientDto
    {
        public int ClientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}