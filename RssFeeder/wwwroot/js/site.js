﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function openDeleteConfirmationModal(item) {
    console.log(item);
}

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


document.addEventListener('DOMContentLoaded', () => {
    
});