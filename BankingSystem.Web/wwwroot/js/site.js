<script>
    var trailingSpan = document.querySelector('.trailing');
    var inputElement = document.querySelector('.form-control.form-icon-trailing');

    inputElement.addEventListener('input', function() {
        if (inputElement.value) {
        trailingSpan.style.display = 'inline'; // Qiymat kiritilgan bo'lsa, X simvolini ko'rsatamiz
        } else {
        trailingSpan.style.display = 'none'; // Qiymat kiritilmagan bo'lsa, X simvolini yashiramiz
        }
    });

    trailingSpan.addEventListener('click', function() {
        inputElement.value = ''; // X simvolini bosganda input qiymatini tozalaymiz
    trailingSpan.style.display = 'none'; // X simvolini yashiramiz
    });
</script>