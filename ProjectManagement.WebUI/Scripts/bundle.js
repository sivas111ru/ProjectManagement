var classedDropDownListOnChangeListener = function (controller) {
    var $this = $(controller);

    $this
        .removeClass()
        .addClass("form-control")
        .addClass("colored-dropdown")
        .addClass($this.find("option:selected").attr("class"));
}

$("select.colored-dropdown").change(function () {
    classedDropDownListOnChangeListener(this);
});

$("select.colored-dropdown").each(function (index, item) {
    classedDropDownListOnChangeListener(item);
})