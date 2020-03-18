// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', () => {
    function hasValidInput(value) {
        return value.trim().length > 0;
    }

    function validateInputs(rssLinkInputs) {
        const results = {};
        if (!hasValidInput(rssLinkInputs["rssFeedName"])) {
            results["feedNameError"] = "The feed name is required";
        }
    }

    $("#addLinkButton").on("click", function () {
        const url = $(this).data("url");
        $.get(url, { message: "Test Message"}).done(function (data) {
            $("#modalContainer").html(data);
            $("#modalContainer > .modal").modal("show");
        });
    });

    $(document).on("click", "#newRssLinkModalCloseButton", function () {
        $("#modalContainer").html("");
    });

    $(document).on("input", "#rssLinkDescriptionInput", function() {
        const value = $(this).val;
        if (value.length > 100) {
            this.value = this.value.substring(0, 100);
        }
    });

    $(document).on("click", "#confirmAddLinkButton", function () {
        const postUrl = $(this).data("url");
        const rssFeedName = document.querySelector("#rssLinkNameInput").value;
        const rssFeedUrl = document.querySelector("#rssLinkUrlInput").value;
        const rssFeedDescription = document.querySelector("#rssLinkDescriptionInput").value;

        $.ajax(postUrl, {
            method: "POST",
            data: {
                name: rssFeedName,
                url: rssFeedUrl,
                description: rssFeedDescription
            },
            success: function (message) {
                console.log("Success is called...");
                console.log(message);
            },
            error: function(message) {
                console.log("Error");
            }
        });
    });
});