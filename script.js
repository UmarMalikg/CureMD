$(document).ready(function () {
  let allBooks = [];
  let startIndex = 0;
  let booksPerPage = 20;
  let booksToShow = [];
  // Function to fetch books from JSON file and display them
  $.ajax({
    url: "books.json",
    dataType: "json",
    method: "GET",
    success: function (data) {
      allBooks = data;
      display_books();
    },
    error: function (xhr, status, error) {
      console.error("Error fetching books:", error);
    },
  });

  // Function to display books
  function display_books() {
    const booksDiv = $("#all-books");
    booksDiv.empty(); // Clear existing content
    booksToShow = allBooks.slice(startIndex, startIndex + booksPerPage);
    render_books_in_table(allBooks);
    render_books(booksToShow);
    update_buttons_visiblity();
  }

  function render_books(books) {
    const booksDiv = $("#all-books");
    booksDiv.empty(); // Clear existing content
    books.forEach((book) => {
      const bookDiv = $("<div>").addClass("book");
      const imgDiv = $("<div>").addClass("b-book-img");
      $("<img>")
        .attr("src", book.imageLink)
        .attr("alt", "Book Image")
        .appendTo(imgDiv);
      bookDiv.append(imgDiv);
      $("<h4>").addClass("b-name").text(book.title).appendTo(bookDiv);
      $("<p>").addClass("b-price").text(book.price).appendTo(bookDiv);
      booksDiv.append(bookDiv);
    });
  }

  function update_buttons_visiblity() {
    if (startIndex === 0) {
      $("#previous-books").addClass("hide");
    } else {
      $("#previous-books").removeClass("hide");
    }
    if (startIndex + booksPerPage >= allBooks.length) {
      $("#next-books").addClass("hide");
    } else {
      $("#next-books").removeClass("hide");
    }
  }

  $("#previous-books").click(function () {
    startIndex -= booksPerPage;
    display_books();
  });
  $("#next-books").click(function () {
    startIndex += booksPerPage;
    display_books();
  });

  $("#search").keyup(function () {
    const title = $(this).val().trim().toLowerCase();
    if (title === "") {
      render_books(booksToShow); // Display all books if search input is empty
    } else {
      const filteredBooks = booksToShow.filter((book) =>
        book.title.toLowerCase().includes(title)
      );
      render_books(filteredBooks); // Display filtered books based on title
    }
  });

  function render_books_in_table(books) {
    const tableBody = $("#books-table");
    tableBody.empty();
    books.forEach((book) => {
      const tableRow = $("<tr>");
      $("<td>").text(book.title).appendTo(tableRow);
      $("<td>").text(book.author).appendTo(tableRow);
      $("<td>").text(book.price).appendTo(tableRow);
      tableBody.append(tableRow);
    });
  }

  // search books from table
  $("#search-book-in-table").keyup(function () {
    const title = $(this).val().trim().toLowerCase();
    if (title === "") {
      render_books_in_table(allBooks); // Display all books if search input is empty
    } else {
      const filteredBooks = allBooks.filter((book) =>
        book.title.toLowerCase().includes(title)
      );
      render_books_in_table(filteredBooks); // Display filtered books based on title
    }
  });
});
