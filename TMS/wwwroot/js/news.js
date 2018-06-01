var url = 'https://newsapi.org/v2/everything?q=truck&apiKey=4a403682270c48cf9b393754d0c12adf';
    document.onload = launchOnStart(url);

function mySearchFunction() {
    var search = document.getElementById("mySearchText").value.toLowerCase();
    var url;

    if (search.indexOf('truck') > -1) {
        url = 'https://newsapi.org/v2/everything?q=' + search + '&apiKey=4a403682270c48cf9b393754d0c12adf';
        launchOnStart(url);
    } else {
        alert("Make sure you have the word 'truck' as keyword!");
    }
}

function launchOnStart(url) {
    var req = new Request(url);

    fetch(req)
        .then((resp) => resp.json())
        .then((data) => {
                var container = $('<div></div>');
                console.log(data.articles);
                data.articles.forEach(function (article) {
                    container.append($(
                        '<div class="card mb-4">' +
                        '<img class="card-img-top" src="' + article.urlToImage + '" alt="Card image cap">' +
                        '<div class="card-body">' +
                        '<h5 class="card-title">' + article.title + '</h5>' +
                        '<p class="card-text">' + article.description + '</p>' +
                        '<p <small class="text-muted"><small class="text-muted"><a href="' + article.url + '">' + article.url + '</a></small></p>' +
                        '<p class="card-text"><small class="text-muted">' + article.publishedAt + '</small></p>' +
                        '</div>' +
                        '</div>'
                    ));
                });
                $('#demo').html(container);
            }
        );
}