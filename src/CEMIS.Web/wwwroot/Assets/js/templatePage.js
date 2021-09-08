$('.triggerU').on('click', handleAjaxModalX);

function handleAjaxModalX(e) {
    e.preventDefault();
        let url = $(this).attr('data-url');
        let title = $(this).attr('data-title');
        let formId = '#' + $(this).attr('data-formid');
        let textAreaId = '#' + $(this).attr('data-textareaid');

    console.log(url, title, $(formId), $(textAreaId));
    //return;

        let ajaxModal = $("#ajaxModal").modal();
        let editorIns;

        ajaxModal.modal('show');

        ajaxModal.on('shown.bs.modal', loadData(url));
        ajaxModal.on('hide.bs.modal', cleanDom);

        function cleanDom(){
            console.log("Clean Dom!");
            editorIns.destroy();
        }

        function loadData(url) {

        function attachToDOM(data, status) {
            let $form = $(formId), $textArea = $(textAreaId);
            console.log(data);

            $form.removeClass('d-none');

            $textArea[0].innerHTML = '<p>Rees ftftrf</p>';

            editorIns = CKEDITOR.replace('test');

            ajaxModal.find(".modal-header").text(title);
            ajaxModal.find(".modal-body").html($form);
        }

            try {
                return $.get(url, attachToDOM);
            } catch (e) {
                console.log(e);
                ajaxModal.find(".modal-header").text("Oops!");
                ajaxModal.find(".modal-body").text("An error occurred while loading this data. Please try again.");
                return;
            }
        }
    }