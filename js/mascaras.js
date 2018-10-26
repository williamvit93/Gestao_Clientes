$(document).ready(function () {
    $('.telefone').inputmask({ mask: "(99)9999-9999" });
    $('.celular').inputmask({ mask: "(99)99999-9999" });
    $('.cep').inputmask({ mask: "99999-999" });
    $('.fax').inputmask({ mask: "(99)9999-9999" });
    $('.cpf').inputmask({ mask: "999.999.999-99" });
    $('.cnpj').inputmask({ mask: "99.999.999/9999-99" });
    $('.rg').inputmask({ mask: "99.999.999-99" });
    $('.frequenciaMedicamento').inputmask({ mask: "99/99H" });
    $('.money').inputmask({ mask: "R$ 9.999,99" });

});