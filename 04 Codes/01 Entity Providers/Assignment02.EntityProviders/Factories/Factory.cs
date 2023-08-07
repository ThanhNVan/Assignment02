using System;

namespace Assignment02.EntityProviders;

public static class Factory
{
    #region [ Methods - Author ]
    public static Author CreateAuthor(string firstname,
                                string lastname,
                                string phone,
                                string email,
                                string address,
                                string city,
                                string state,
                                string zip) {
        var result = new Author() { 
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            LastUpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            FirstName = firstname,
            LastName = lastname,
            Phone = phone,
            Email = email,
            Address = address,
            City = city,
            State = state,
            Zip = zip
        };

        return result;
    }
    #endregion

    #region [ Methods - Book ]
    public static Book CreateBook(string title,
                                    string type,
                                    decimal price,
                                    string advance,
                                    string royalty,
                                    decimal sales,
                                    string notes,
                                    DateTime publishDate,
                                    string publisherId) {
        var result = new Book() {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            LastUpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            Title = title,
            Type = type,
            Price = price,
            Advance = advance,
            Royalty = royalty, 
            Sales = sales,
            Note = notes,
            PublishedDate = publishDate,
            PublisherId = publisherId
        };

        return result;
    }
    #endregion

    #region [ Methods - BookAuthor ]
    public static BookAuthor CreateBookAuthor(string authorId,
                                                string bookId,
                                                string authorOrder,
                                                string royalityPercentage) {
        var result = new BookAuthor() {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            LastUpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            AuthorId = authorId,
            BookId = bookId,
            AuthorOrder = authorOrder,
            RoyalityPercentage = royalityPercentage
        };

        return result;
    }
    #endregion

    #region [ Methods - Publisher ]
    public static Publisher CreatePublisher(string name,
                                            string address,
                                            string city,
                                            string state,
                                            string country) {
        var result = new Publisher() {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            LastUpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            Name = name,
            Address = address,
            City = city,
            State = state,
            Country = country
        };

        return result;
    }
    #endregion

    #region [ Methods - Role ]
    public static Role CreateRole(string description) {
        var result = new Role() {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            LastUpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            Description = description
        };

        return result;
    }
    #endregion

    #region [ Methods - User ]
    public static User CreateUser(string email,
                                    string password,
                                    string firstName,
                                    string middleName,
                                    string lastName,
                                    DateTime hiredDate,
                                    string roleId,
                                    string publisherId) {
        var result = new User() {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            LastUpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            Email = email,
            Password = password,
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            HiredDate = hiredDate,
            RoleId = roleId,
            PublisherId = publisherId
        };

        return result;
    }
    #endregion
}
