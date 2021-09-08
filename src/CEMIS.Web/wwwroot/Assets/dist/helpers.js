//$tree.on('click', '.edit', function (e)

function handleAjaxModal(e) {
    var url = $(e).attr('data-url');
    var ajaxModal = $("#ajaxModal").modal({ show: false });

    ajaxModal.modal('show');

    ajaxModal.on('shown.bs.modal', loadData(url));
    ajaxModal.on('hide.bs.modal', cleanDom);

    function cleanDom(){
        console.log("Clean Dom!");
    }

    function loadData(url) {
        function attachToDOM(data, status){
            ajaxModal.find(".modal-content").html(data);
        }
        try {
            $.get(url, attachToDOM);
        } catch (e) {
            ajaxModal.find(".modal-header").text("Oops!");
            ajaxModal.find(".modal-body").text("An error occurred while loading this data. Please try again.");
            return;
        }
    }
}





function handleAjaxModal2(e) {
    $("#selectTemplateModal").hide();
    $('body').removeClass('modal-open');
    $('#selectTemplateModal').removeClass('show');
    $('#selectTemplateModal').attr("aria-hidden", "true");
    $('#selectTemplateModal').removeAttr('aria-modal');
    $(".modal-backdrop").remove();

    var url = $(e).attr('data-url');
    var ajaxModal = $("#ajaxModal").modal({ show: false });

    ajaxModal.modal('show');

    ajaxModal.on('shown.bs.modal', loadData(url));
    ajaxModal.on('hide.bs.modal', cleanDom);

    function cleanDom() {
        console.log("Clean Dom!");
    }

    function loadData(url) {
        function attachToDOM(data, status) {
            ajaxModal.find(".modal-content").html(data);
        }
        try {
            $.get(url, attachToDOM);
        } catch (e) {
            ajaxModal.find(".modal-header").text("Oops!");
            ajaxModal.find(".modal-body").text("An error occurred while loading this data. Please try again.");
            return;
        }
    }
}