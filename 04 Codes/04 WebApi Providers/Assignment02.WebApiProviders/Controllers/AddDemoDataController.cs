using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment02.WebApiProviders;

//[ApiController]
//[Route("Api/V1/[controller]")]
public class AddDemoDataController : ControllerBase
{
	#region [ Fields ]
	private readonly IDbContextFactory<AppDbContext> _dbContext;
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
	public AddDemoDataController(IDbContextFactory<AppDbContext> dbContext) {
        _dbContext = dbContext;	
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

			var dbContext = await this._dbContext.CreateDbContextAsync();
			var strategy = dbContext.Database.CreateExecutionStrategy();
			await strategy.ExecuteAsync( async () => {
				using var transaction = await dbContext.Database.BeginTransactionAsync();
				try {
					await dbContext.AddRangeAsync(this.PublisherList);
					await dbContext.AddRangeAsync(this.BookList);
					await dbContext.AddRangeAsync(this.AuthorList);
					await dbContext.AddRangeAsync(this.BookAuthorList);
					await dbContext.AddRangeAsync(this.RoleList);
					await dbContext.AddRangeAsync(this.UserList);
                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
					
                } catch (Exception ex) {
					var aa = ex.Message;
                    await transaction.RollbackAsync();
                    throw;
				}
            });
                return Ok();

		} catch (Exception ex) {
            return BadRequest();
            throw;
		}
	}
	#endregion

	#region [ Private Methods - Seed Data ]
	private void LoadAddData() {
		this.LoadPublisher();

		this.LoadBook();
        this.LoadAuthor();
		this.LoadBookAuthor();
		this.LoadRole();

		this.LoadUser();
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
										publisherId: this.PublisherList[0].Id); 
		
		var book_1 = Factory.CreateBook(title: "Book title 1",
										type: "Book type 1",
										price: 151_111,
										advance: "Book advance 1",
										royalty: "Book royalty 1",
										sales: 1,
										notes: "Book note 1",
										publishDate: DateTime.UtcNow.AddDays(1),
										publisherId: this.PublisherList[0].Id); 
		
		var book_2 = Factory.CreateBook(title: "Book title 2",
										type: "Book type 2",
										price: 252_222,
										advance: "Book advance 2",
										royalty: "Book royalty 2",
										sales: 2,
										notes: "Book note 2",
										publishDate: DateTime.UtcNow.AddDays(2),
										publisherId: this.PublisherList[1].Id); 
		
		var book_3 = Factory.CreateBook(title: "Book title 3",
										type: "Book type 3",
										price: 353_333,
										advance: "Book advance 3",
										royalty: "Book royalty 3",
										sales: 3,
										notes: "Book note 3",
										publishDate: DateTime.UtcNow.AddDays(3),
										publisherId: this.PublisherList[1].Id); 
		
		var book_4 = Factory.CreateBook(title: "Book title 4",
										type: "Book type 4",
										price: 454_444,
										advance: "Book advance 4",
										royalty: "Book royalty 4",
										sales: 4,
										notes: "Book note 4",
										publishDate: DateTime.UtcNow.AddDays(4),
										publisherId: this.PublisherList[2].Id); 
		
		var book_5 = Factory.CreateBook(title: "Book title 5",
										type: "Book type 5",
										price: 555_555,
										advance: "Book advance 5",
										royalty: "Book royalty 5",
										sales: 5,
										notes: "Book note 5",
										publishDate: DateTime.UtcNow.AddDays(5),
										publisherId: this.PublisherList[2].Id); 
		
		var book_6 = Factory.CreateBook(title: "Book title 6",
										type: "Book type 6",
										price: 666_666,
										advance: "Book advance 6",
										royalty: "Book royalty 6",
										sales: 6,
										notes: "Book note 6",
										publishDate: DateTime.UtcNow.AddDays(6),
										publisherId: this.PublisherList[3].Id); 
		
		var book_7 = Factory.CreateBook(title: "Book title 7",
										type: "Book type 7",
										price: 777_777,
										advance: "Book advance 7",
										royalty: "Book royalty 7",
										sales: 7,
										notes: "Book note 7",
										publishDate: DateTime.UtcNow.AddDays(7),
										publisherId: this.PublisherList[3].Id); 
		
		var book_8 = Factory.CreateBook(title: "Book title 8",
										type: "Book type 8",
										price: 888_888,
										advance: "Book advance 8",
										royalty: "Book royalty 8",
										sales: 8,
										notes: "Book note 8",
										publishDate: DateTime.UtcNow.AddDays(8),
										publisherId: this.PublisherList[2].Id); 
		
		var book_9 = Factory.CreateBook(title: "Book title 9",
										type: "Book type 9",
										price: 999_999,
										advance: "Book advance 9",
										royalty: "Book royalty 9",
										sales: 9,
										notes: "Book note 9",
										publishDate: DateTime.UtcNow.AddDays(9),
										publisherId: this.PublisherList[3].Id); 
		
		var book_10 = Factory.CreateBook(title: "Book title 10",
										type: "Book type 10",
										price: 1010_1010,
										advance: "Book advance 10",
										royalty: "Book royalty 10",
										sales: 10,
										notes: "Book note 10",
										publishDate: DateTime.UtcNow.AddDays(10),
										publisherId: this.PublisherList[1].Id); 

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

	private void LoadPublisher() {
		var publisher_0 = Factory.CreatePublisher(name: "Publisher name 0",
													address: "Publisher address 0",
													city: "District 3",
													state: "Ho CHi Minh city",
													country: "Vietnam");
		
		var publisher_1 = Factory.CreatePublisher(name: "Publisher name 1",
													address: "Publisher address 1",
													city: "District 9",
													state: "Ho CHi Minh city",
													country: "Vietnam");
		
		var publisher_2 = Factory.CreatePublisher(name: "Publisher name 2",
													address: "Publisher address 2",
													city: "District 10",
													state: "Ho CHi Minh city",
													country: "Vietnam");
		
		var publisher_3 = Factory.CreatePublisher(name: "Publisher name 3",
													address: "Publisher address 3",
													city: "Binh Thanh District",
													state: "Ho CHi Minh city",
													country: "Vietnam");
		this.PublisherList.Add(publisher_0);
		this.PublisherList.Add(publisher_1);
		this.PublisherList.Add(publisher_2);
		this.PublisherList.Add(publisher_3);
	}

	private void LoadBookAuthor() {
		var bookAuthor_0 = Factory.CreateBookAuthor(authorId: this.AuthorList[0].Id,
													bookId: this.BookList[0].Id,
													authorOrder: "BookAuthor author order 0",
													royalityPercentage: "BookAuthor royality percentage");

		var bookAuthor_1 = Factory.CreateBookAuthor(authorId: this.AuthorList[0].Id,
													bookId: this.BookList[1].Id,
													authorOrder: "BookAuthor author order 1",
													royalityPercentage: "BookAuthor royality percentage 1");

		var bookAuthor_2 = Factory.CreateBookAuthor(authorId: this.AuthorList[0].Id,
													bookId: this.BookList[2].Id,
													authorOrder: "BookAuthor author order 2",
													royalityPercentage: "BookAuthor royality percentage 2");
		
		var bookAuthor_3 = Factory.CreateBookAuthor(authorId: this.AuthorList[1].Id,
													bookId: this.BookList[2].Id,
													authorOrder: "BookAuthor author order 3",
													royalityPercentage: "BookAuthor royality percentage 3");


		var bookAuthor_4 = Factory.CreateBookAuthor(authorId: this.AuthorList[3].Id,
													bookId: this.BookList[2].Id,
													authorOrder: "BookAuthor author order 4",
													royalityPercentage: "BookAuthor royality percentage 4");

		var bookAuthor_5 = Factory.CreateBookAuthor(authorId: this.AuthorList[3].Id,
													bookId: this.BookList[3].Id,
													authorOrder: "BookAuthor author order 5",
													royalityPercentage: "BookAuthor royality percentage 5");

		var bookAuthor_6 = Factory.CreateBookAuthor(authorId: this.AuthorList[3].Id,
													bookId: this.BookList[4].Id,
													authorOrder: "BookAuthor author order 6",
													royalityPercentage: "BookAuthor royality percentage 6");

		var bookAuthor_7 = Factory.CreateBookAuthor(authorId: this.AuthorList[4].Id,
													bookId: this.BookList[5].Id,
													authorOrder: "BookAuthor author order 7",
													royalityPercentage: "BookAuthor royality percentage 7");

		var bookAuthor_8 = Factory.CreateBookAuthor(authorId: this.AuthorList[1].Id,
													bookId: this.BookList[5].Id,
													authorOrder: "BookAuthor author order 8",
													royalityPercentage: "BookAuthor royality percentage 8");
		
		var bookAuthor_9 = Factory.CreateBookAuthor(authorId: this.AuthorList[5].Id,
													bookId: this.BookList[6].Id,
													authorOrder: "BookAuthor author order 9",
													royalityPercentage: "BookAuthor royality percentage 9");

		var bookAuthor_10 = Factory.CreateBookAuthor(authorId: this.AuthorList[1].Id,
													bookId: this.BookList[6].Id,
													authorOrder: "BookAuthor author order 10",
													royalityPercentage: "BookAuthor royality percentage 10");
		
		var bookAuthor_11 = Factory.CreateBookAuthor(authorId: this.AuthorList[0].Id,
													bookId: this.BookList[7].Id,
													authorOrder: "BookAuthor author order 11",
													royalityPercentage: "BookAuthor royality percentage 11");

		var bookAuthor_12 = Factory.CreateBookAuthor(authorId: this.AuthorList[2].Id,
													bookId: this.BookList[6].Id,
													authorOrder: "BookAuthor author order 12",
													royalityPercentage: "BookAuthor royality percentage 12");
		
		var bookAuthor_13 = Factory.CreateBookAuthor(authorId: this.AuthorList[3].Id,
													bookId: this.BookList[7].Id,
													authorOrder: "BookAuthor author order 13",
													royalityPercentage: "BookAuthor royality percentage 13");


		var bookAuthor_14 = Factory.CreateBookAuthor(authorId: this.AuthorList[4].Id,
													bookId: this.BookList[8].Id,
													authorOrder: "BookAuthor author order 14",
													royalityPercentage: "BookAuthor royality percentage 14");
	
		var bookAuthor_15 = Factory.CreateBookAuthor(authorId: this.AuthorList[5].Id,
													bookId: this.BookList[9].Id,
													authorOrder: "BookAuthor author order 15",
													royalityPercentage: "BookAuthor royality percentage 15");

		var bookAuthor_16 = Factory.CreateBookAuthor(authorId: this.AuthorList[0].Id,
													bookId: this.BookList[10].Id,
													authorOrder: "BookAuthor author order 16",
													royalityPercentage: "BookAuthor royality percentage 16");
		
		var bookAuthor_17 = Factory.CreateBookAuthor(authorId: this.AuthorList[5].Id,
													bookId: this.BookList[10].Id,
													authorOrder: "BookAuthor author order 17",
													royalityPercentage: "BookAuthor royality percentage 17");
		this.BookAuthorList.Add(bookAuthor_0);
		this.BookAuthorList.Add(bookAuthor_1);
		this.BookAuthorList.Add(bookAuthor_2);
		this.BookAuthorList.Add(bookAuthor_3);
		this.BookAuthorList.Add(bookAuthor_4);
		this.BookAuthorList.Add(bookAuthor_5);
		this.BookAuthorList.Add(bookAuthor_6);
		this.BookAuthorList.Add(bookAuthor_7);
		this.BookAuthorList.Add(bookAuthor_8);
		this.BookAuthorList.Add(bookAuthor_9);
		this.BookAuthorList.Add(bookAuthor_10);
		this.BookAuthorList.Add(bookAuthor_11);
		this.BookAuthorList.Add(bookAuthor_12);
		this.BookAuthorList.Add(bookAuthor_13);
		this.BookAuthorList.Add(bookAuthor_14);
		this.BookAuthorList.Add(bookAuthor_15);
		this.BookAuthorList.Add(bookAuthor_16);
		this.BookAuthorList.Add(bookAuthor_17);
	}

	private void LoadRole() {
		var role_0 = Factory.CreateRole("Employee");
		var role_1 = Factory.CreateRole("Manager");
		var role_2 = Factory.CreateRole("Cashier");

		this.RoleList.Add(role_0);
		this.RoleList.Add(role_1);
		this.RoleList.Add(role_2);
	}

	private void LoadUser() {
		var user_0 = Factory.CreateUser(email: "Thanh.van0@gmail.com",
										password: "123456",
										firstName: "Thanh",
										middleName: "Nhat",
										lastName: "Van",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[0].Id,
										publisherId: this.PublisherList[0].Id);
		
		var user_1 = Factory.CreateUser(email: "An.Tran0@gmail.com",
										password: "123456",
										firstName: "An",
										middleName: "Vinh",
										lastName: "Tran",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[2].Id,
										publisherId: this.PublisherList[0].Id);
		
		var user_2 = Factory.CreateUser(email: "Andy.Tran0@gmail.com",
										password: "123456",
										firstName: "Andy",
										middleName: "Vinh",
										lastName: "Tran",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[1].Id,
										publisherId: this.PublisherList[0].Id);
		
		var user_3 = Factory.CreateUser(email: "Thanh.van1@gmail.com",
										password: "123456",
										firstName: "Thanh",
										middleName: "Nhat",
										lastName: "Van",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[0].Id,
										publisherId: this.PublisherList[1].Id);
		
		var user_4 = Factory.CreateUser(email: "An.Tran1@gmail.com",
										password: "123456",
										firstName: "An",
										middleName: "Vinh",
										lastName: "Tran",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[2].Id,
										publisherId: this.PublisherList[1].Id);
		
		var user_5 = Factory.CreateUser(email: "Andy.Tran1@gmail.com",
										password: "123456",
										firstName: "Andy",
										middleName: "Vinh",
										lastName: "Tran",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[1].Id,
										publisherId: this.PublisherList[1].Id);

		var user_6 = Factory.CreateUser(email: "Thanh.van2@gmail.com",
										password: "123456",
										firstName: "Thanh",
										middleName: "Nhat",
										lastName: "Van",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[0].Id,
										publisherId: this.PublisherList[2].Id);
		
		var user_7 = Factory.CreateUser(email: "An.Tran2@gmail.com",
										password: "123456",
										firstName: "An",
										middleName: "Vinh",
										lastName: "Tran",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[2].Id,
										publisherId: this.PublisherList[2].Id);
		
		var user_8 = Factory.CreateUser(email: "Andy.Tran2@gmail.com",
										password: "123456",
										firstName: "Andy",
										middleName: "Vinh",
										lastName: "Tran",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[1].Id,
										publisherId: this.PublisherList[2].Id);

		var user_9 = Factory.CreateUser(email: "Thanh.van3@gmail.com",
										password: "123456",
										firstName: "Thanh",
										middleName: "Nhat",
										lastName: "Van",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[0].Id,
										publisherId: this.PublisherList[2].Id);
		
		var user_10 = Factory.CreateUser(email: "An.Tran3@gmail.com",
										password: "123456",
										firstName: "An",
										middleName: "Vinh",
										lastName: "Tran",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[2].Id,
										publisherId: this.PublisherList[3].Id);
		
		var user_11 = Factory.CreateUser(email: "Andy.Tran3@gmail.com",
										password: "123456",
										firstName: "Andy",
										middleName: "Vinh",
										lastName: "Tran",
										hiredDate: DateTime.UtcNow,
										roleId: this.RoleList[1].Id,
										publisherId: this.PublisherList[3].Id);
		this.UserList.Add(user_0);
		this.UserList.Add(user_1);
		this.UserList.Add(user_2);
		this.UserList.Add(user_3);
		this.UserList.Add(user_4);
		this.UserList.Add(user_5);
		this.UserList.Add(user_6);
		this.UserList.Add(user_7);
		this.UserList.Add(user_8);
		this.UserList.Add(user_9);
		this.UserList.Add(user_10);
		this.UserList.Add(user_11);
	}
    #endregion
}
