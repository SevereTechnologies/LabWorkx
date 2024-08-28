namespace RequestOrder.Domain.Abstractions;

/// <summary>
/// Entity Interface
/// </summary>
public interface IEntity
{
    public DateTime? CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
    public string? LastUpdatedBy { get; set; }
}

/// <summary>
/// Generic Version of the Interface which inherits from IEntity interface ABOVE
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}

/// <summary>
/// abstract base entity class that will inherits from IEntity<T> ABOVE 
/// All new Entities created will inherit from this class.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
    public string? LastUpdatedBy { get; set; }
}