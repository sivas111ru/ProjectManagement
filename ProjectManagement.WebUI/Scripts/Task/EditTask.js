var classedDropDownListOnChangeListener = function (controller_id) {
    var $this = $(controller_id);

    $this
        .removeClass()
        .addClass("form-control")
        .addClass($this.find("option:selected").attr("class"));
}

$("select").change(function() {
    classedDropDownListOnChangeListener(this);
});

$("select").each(function(index, item) {
    classedDropDownListOnChangeListener(item);
})