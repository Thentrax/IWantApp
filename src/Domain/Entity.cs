﻿namespace IWantApp.Domain;

public abstract class Entity
{
    public Entity()
    {
        Id= Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
}