$(".openUpdateTransactionModalBtn").on("click", function() {
    var date = $(this).closest('tr').find('.transaction-date').html();
    var name = $(this).closest('tr').find('.transaction-name').html();
    var amount = $(this).closest('tr').find('.transaction-amount').html();
    var category = $(this).closest('tr').find('.transaction-category').html();

    $("#insert-transaction-form #insertTransaction-Date").val($.trim(date));

    $("#exampleModalToggle").modal("show");
})