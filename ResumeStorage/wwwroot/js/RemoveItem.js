$(document).ready(function () {
    $(document).on('click', '.remove-button', function () {
        const parent = $(this).parent();
        $(parent).remove();
    });
});