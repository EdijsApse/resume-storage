$(document).ready(function ()
{
    const btn = $("#clone-item");

    $(btn).on("click", function ()
    {
        const itemToCopy = $("#cloneable").clone();

        const inputs = $(itemToCopy).find("input");
        const selects = $(itemToCopy).find("select");
        const textareas = $(itemToCopy).find("textarea");

        inputs.each(updateNameAndValue);
        selects.each(updateNameAndValue);
        textareas.each(updateNameAndValue);

        $(itemToCopy).attr("id", "");
        $(itemToCopy).removeClass("d-none");
        $(".form-items-list").append(itemToCopy);
    });
});

function updateNameAndValue() {
    const oldName = $(this).attr("name");
    const nameOfArray = $("#FieldName").val();
    const listOfItems = $(".form-items-list > div");
    const newName = `${nameOfArray}[${listOfItems.length}].${oldName}`;

    const isDateInput = $(this).attr('type') == 'date';

    $(this).attr('name', newName);

    if (isDateInput) $(this).attr('value', '');
}