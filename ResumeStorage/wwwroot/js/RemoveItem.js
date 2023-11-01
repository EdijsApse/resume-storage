$(document).ready(function () {
    $(document).on('click', '.remove-button', function () {
        const parent = $(this).parent();
        const id = $(parent).find('.item-id').val();

        if (id > 0) {
            $.post(DELETE_ENDPOINT, { id }, function (data, status) {
                if (data.success) $(parent).remove();

                alert(data.message);
            });
        } else {
            $(parent).remove();
        }
    });
});