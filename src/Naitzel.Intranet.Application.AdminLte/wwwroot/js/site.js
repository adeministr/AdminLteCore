$(document).ready(function () {

    if ($.fn.mvcgrid != undefined) {
        $.fn.mvcgrid.lang = {
            text: {
                'contains': 'Contém',
                'equals': 'É igual a',
                'not-equals': 'Não é igual a',
                'starts-with': 'Começa com',
                'ends-with': 'Termina com'
            },
            number: {
                'equals': 'É igual a',
                'not-equals': 'Não é igual a',
                'less-than': 'Menor que',
                'greater-than': 'Maior que',
                'less-than-or-equal': 'Menor ou igual',
                'greater-than-or-equal': 'Maior que ou igual'
            },
            date: {
                'equals': 'É igual a',
                'not-equals': 'Não é igual a',
                'earlier-than': 'Antes de',
                'later-than': 'Depois de',
                'earlier-than-or-equal': 'Antes ou igual',
                'later-than-or-equal': 'Depois ou igual'
            },
            enum: {
                'equals': 'É igual a',
                'not-equals': 'Não é igual a'
            },
            guid: {
                'equals': 'É igual a',
                'not-equals': 'Não é igual a'
            },
            boolean: {
                'equals': 'É igual a',
                'not-equals': 'Não é igual a'
            },
            filter: {
                'apply': '&#10004;',
                'remove': '&#10008;'
            },
            operator: {
                'select': '',
                'and': 'E',
                'or': 'OU'
            }
        };
    }
})