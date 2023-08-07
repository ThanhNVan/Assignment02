using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Microsoft.AspNetCore.Mvc;

namespace Assignment02.WebApiProviders;

[ApiController]
[Route("Api/V1/[controller]")]
public class AddDemoDataController : ControllerBase
{
	#region [ Fields ]
	private readonly AppDbContext _dbContext;
	#endregion

	#region [ Properties ]
	public List<Author> AuthorList { get; set; }	 
	public List<BookAuthor> BookAuthorList { get; set; }	
	public List<Book> BookList { get; set; }	
	public List<Publisher> PublisherList { get; set; }	
	public List<Role> RoleList { get; set; }	
	public List<User> UserList { get; set; }	
	#endregion

	#region [ CTor ]
	public AddDemoDataController(AppDbContext dataContext) {
		_dbContext = dataContext;	
		AuthorList = new List<Author>();
		BookAuthorList = new List<BookAuthor>();
		BookList = new List<Book>();
		PublisherList = new List<Publisher>();
		RoleList = new List<Role>();
		UserList = new List<User>();

		LoadAddData();
    }
    #endregion

    #region [ Public Methods - AddDemoDataAsync ]
    [HttpGet]
	public async Task<IActionResult> AddDemoDataAsync() {
		try {

		} catch (Exception ex) {

			throw;
		}
	}
	#endregion

	#region [ Private Methods - Seed Data ]
	private void LoadAddData() {
		LoadAuthor();
		LoadBook();
    }

	private void LoadAuthor() {
		var author_0 = Factory.CreateAuthor(firstname: "Author firstname 0",
											lastname: "Author lastname 0",
											phone: "0397300000",
											email: "author_0@email.com",
											address: "Author address 0",
											city: "Author city 0",
											state: "Author state 0",
											zip: "700000");
		
		var author_1 = Factory.CreateAuthor(firstname: "Author firstname 1",
											lastname: "Author lastname 1",
											phone: "0397311111",
											email: "author_1@email.com",
											address: "Author address 1",
											city: "Author city 1",
											state: "Author state 1",
											zip: "711111");
		
		var author_2 = Factory.CreateAuthor(firstname: "Author firstname 2",
											lastname: "Author lastname 2",
											phone: "0397322222",
											email: "author_2@email.com",
											address: "Author address 2",
											city: "Author city 2",
											state: "Author state 2",
											zip: "722222");
		
		var author_3 = Factory.CreateAuthor(firstname: "Author firstname 3",
											lastname: "Author lastname 3",
											phone: "0397333333",
											email: "author_3@email.com",
											address: "Author address 3",
											city: "Author city 3",
											state: "Author state 3",
											zip: "733333");
		
		var author_4 = Factory.CreateAuthor(firstname: "Author firstname 4",
											lastname: "Author lastname 4",
											phone: "0497444444",
											email: "author_4@email.com",
											address: "Author address 4",
											city: "Author city 4",
											state: "Author state 4",
											zip: "744444");
		
		var author_5 = Factory.CreateAuthor(firstname: "Author firstname 5",
											lastname: "Author lastname 5",
											phone: "0597555555",
											email: "author_5@email.com",
											address: "Author address 5",
											city: "Author city 5",
											state: "Author state 5",
											zip: "755555");

        AuthorList.Add(author_0);
        AuthorList.Add(author_1);
        AuthorList.Add(author_2);
        AuthorList.Add(author_3);
        AuthorList.Add(author_4);
        AuthorList.Add(author_5);
    }

	private void LoadBook() {
		var book_0 = Factory.CreateBook(title: "Book title 0",
										type: "Book type 0",
										price: 150_000,
										advance: "Book advance 0",
										royalty: "Book royalty 0",
										sales: 0,
										notes: "Book note 0",
										publishDate: DateTime.UtcNow.AddDays(0),
										publisherId: "Book publisherId 0"); 
		
		var book_1 = Factory.CreateBook(title: "Book title 1",
										type: "Book type 1",
										price: 151_111,
										advance: "Book advance 1",
										royalty: "Book royalty 1",
										sales: 1,
										notes: "Book note 1",
										publishDate: DateTime.UtcNow.AddDays(1),
										publisherId: "Book publisherId 1"); 
		
		var book_2 = Factory.CreateBook(title: "Book title 2",
										type: "Book type 2",
										price: 252_222,
										advance: "Book advance 2",
										royalty: "Book royalty 2",
										sales: 2,
										notes: "Book note 2",
										publishDate: DateTime.UtcNow.AddDays(2),
										publisherId: "Book publisherId 2"); 
		
		var book_3 = Factory.CreateBook(title: "Book title 3",
										type: "Book type 3",
										price: 353_333,
										advance: "Book advance 3",
										royalty: "Book royalty 3",
										sales: 3,
										notes: "Book note 3",
										publishDate: DateTime.UtcNow.AddDays(3),
										publisherId: "Book publisherId 3"); 
		
		var book_4 = Factory.CreateBook(title: "Book title 4",
										type: "Book type 4",
										price: 454_444,
										advance: "Book advance 4",
										royalty: "Book royalty 4",
										sales: 4,
										notes: "Book note 4",
										publishDate: DateTime.UtcNow.AddDays(4),
										publisherId: "Book publisherId 4"); 
		
		var book_5 = Factory.CreateBook(title: "Book title 5",
										type: "Book type 5",
										price: 555_555,
										advance: "Book advance 5",
										royalty: "Book royalty 5",
										sales: 5,
										notes: "Book note 5",
										publishDate: DateTime.UtcNow.AddDays(5),
										publisherId: "Book publisherId 5"); 
		
		var book_6 = Factory.CreateBook(title: "Book title 6",
										type: "Book type 6",
										price: 666_666,
										advance: "Book advance 6",
										royalty: "Book royalty 6",
										sales: 6,
										notes: "Book note 6",
										publishDate: DateTime.UtcNow.AddDays(6),
										publisherId: "Book publisherId 6"); 
		
		var book_7 = Factory.CreateBook(title: "Book title 7",
										type: "Book type 7",
										price: 777_777,
										advance: "Book advance 7",
										royalty: "Book royalty 7",
										sales: 7,
										notes: "Book note 7",
										publishDate: DateTime.UtcNow.AddDays(7),
										publisherId: "Book publisherId 7"); 
		
		var book_8 = Factory.CreateBook(title: "Book title 8",
										type: "Book type 8",
										price: 888_888,
										advance: "Book advance 8",
										royalty: "Book royalty 8",
										sales: 8,
										notes: "Book note 8",
										publishDate: DateTime.UtcNow.AddDays(8),
										publisherId: "Book publisherId 8"); 
		
		var book_9 = Factory.CreateBook(title: "Book title 9",
										type: "Book type 9",
										price: 999_999,
										advance: "Book advance 9",
										royalty: "Book royalty 9",
										sales: 9,
										notes: "Book note 9",
										publishDate: DateTime.UtcNow.AddDays(9),
										publisherId: "Book publisherId 9"); 
		
		var book_10 = Factory.CreateBook(title: "Book title 10",
										type: "Book type 10",
										price: 1010_1010,
										advance: "Book advance 10",
										royalty: "Book royalty 10",
										sales: 10,
										notes: "Book note 10",
										publishDate: DateTime.UtcNow.AddDays(10),
										publisherId: "Book publisherId 10"); 

		BookList.Add(book_0);
		BookList.Add(book_1);
		BookList.Add(book_2);
		BookList.Add(book_3);
		BookList.Add(book_4);
		BookList.Add(book_5);
		BookList.Add(book_6);
		BookList.Add(book_7);
		BookList.Add(book_8);
		BookList.Add(book_9);
		BookList.Add(book_10);
	}
	#endregion
}
