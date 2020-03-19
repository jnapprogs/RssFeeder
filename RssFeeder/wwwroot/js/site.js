// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function openDeleteConfirmationModal(item) {
    console.log(item);
}

/**
 * DataTable for the RSS articles
 */
$(function() {
    $("#feedTable").DataTable();
});

$(function() {
    const modalContainer = $("#modalContainer");

    $(".delete-btn").on("click", function () {
        const url = $(this).data("url");
        const feed_id = $(this).data("feed_id");

        $.ajax({
            url: url,
            data: {
                feedId: feed_id
            },
            success: function(data) {
                modalContainer.html(data);
                $("#confirmDeleteModal").show();
            },
            error: function (error) {
                modalContainer.html("");
                alert(error.responseText);
            }
        });
    });

    $(document).on("click", ".remove-modal", function () {
        modalContainer.html("");
    });

    $(document).on("click", "#confirmDeleteButton", function () {
        const url = $(this).data("url");
        const feedId = $(this).data("feed_id");

        console.log("Ready");

        $.ajax({
            url: url,
            type: "POST",
            data: {
                feedId: feedId
            },
            success: function(response) {
                modalContainer.html("");
                window.location.href = response.redirectUrl;
            },
            error: function(error) {
                modalContainer.html("");
                alert(error.responseText);
            }
        });
    });
});

$(function() {
    const modalContainer = $("#modalContainer");

    $(document).on("click", ".edit-btn", function () {
        const feedLink = $(this).data("feedlink");
        const description = $(this).data("description");

        console.log(`Feed link: ${feedLink}`);
        console.log(`Feed description: ${description}`);
    });
});

$(function() {
    $(document).on("change", "#sortOption", function () {
        const selectedIndex = $(this).prop("selectedIndex");
        if (selectedIndex === 0) {
            return;
        }

        const feedUrl = $(this).data("feedurl");
        const sortType = $(this).val();
        const url = $("#articlesContainer").data("url");
        const container = $("#articlesContainer");

        $.ajax({
            url: url,
            data: {
                feedUrl: feedUrl,
                sortType: sortType
            },
            success: function(response) {
                window.location.href = response.redirectUrl;
            }
        });
    });
});
