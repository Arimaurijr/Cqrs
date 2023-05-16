namespace Cqrs.Domain.Domain;

public class Person
{
	public Person()
	{
		Id = Guid.NewGuid();
		CreatedAt = DateTime.Now;
		UpdatedAt = dateTime.Now;
	}
	public Guid Id { get; set; }
	public DateTime CreateAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public string Name { get; set; }	
	public string Cpf { get; set; }
	public string Email { get;set; }
	public DateTime DateBirth { get; set; }

	
	
}
