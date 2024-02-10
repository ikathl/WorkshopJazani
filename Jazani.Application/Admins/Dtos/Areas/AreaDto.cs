﻿namespace Jazani.Application.Admins.Dtos.Areas
{
    public class AreaDto
    {
        public int Id { get; set; }
        public int AreaTypeId { get; set; }
        public string Name { get; set; } = default!;//obligatorio que tenga un valor
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
