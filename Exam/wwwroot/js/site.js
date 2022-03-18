$(document).ready(() => {
    $('.li-category').each(function () {
        this.onmouseover = function () {
            var category = this;
            $('.list-subcategories').each(function () {
                var subcategory = this;

                if (subcategory.dataset.catid == category.dataset.catid) {
                    subcategory.classList.remove('hidden');
                }
            });
        };

        this.onmouseout = function () {
            var category = this;
            $('.list-subcategories').each(function () {
                var subcategory = this;

                if (subcategory.dataset.catid == category.dataset.catid) {
                    subcategory.classList.add('hidden');
                }
            });
        };
    });

    $('.li-subcategory').each(function () {
        this.onmouseover = function () {
            this.parentNode.classList.remove('hidden');
        };

        this.onmouseout = function () {
            this.parentNode.classList.add('hidden');
        };
    });

    $('.btn-find').click(function () {
        let query = $('.input-find')[0].value;
        $.post([
            location.origin,
            'Products',
            'SearchResult'
        ].join('/'),
            {
                query: query
            },
            () => {
                document.location.href = [location.origin, 'Products', 'SearchResult'].join('/');
            }
        );
        
        $('.input-find')[0].value = '';
    });

    $('.btn-sort').click(function () {
        let producers = [];
        let minPrice, maxPrice = 0;
        $('.cb-producers').each(function () {
            if (this.checked) {
                producers.push(this.value);
            }
        });
        minPrice = Number($('.min-price')[0].value);
        maxPrice = Number($('.max-price')[0].value);
        $.post([
            location.origin,
            'Categories',
            'SortProducts'
        ].join('/'),
            {
                producers: producers,
                minPrice: minPrice,
                maxPrice: maxPrice
            },
            () => {
                document.location.href = [location.origin, 'Categories', 'SortProducts'].join('/');
            }
        )
    });

    $('.prod-cart-quantity').change(function (ev) {
        $(this).parent('.change-quantity-form').submit();
    });

    $('.btn-add-to-wish-list').click(function (ev) {
        $.get([
            location.origin,
            'Products',
            'AddToWishList'
        ].join('/'),
            {
                id: this.dataset.id
            },
            () => {
                document.location.reload();
            }
        );
    });

    $('.btn-remove-from-wish-list').click(function () {
        $.get([
            location.origin,
            'Products',
            'RemoveFromWishList'
        ].join('/'),
            {
                id: this.dataset.id
            },
            () => {
                document.location.reload();
            }
        );
    });

    $('.btn-remove-from-basket').click(function () {
        $.get([
            location.origin,
            'Products',
            'RemoveFromCart'
        ].join('/'),
            {
                id: this.dataset.id
            },
            () => {
                document.location.reload();
            }
        );
    });

    $('.btn-make-order').click(function () {
        let prods = [];
        $('.basket-product-card').each(function () {
            let id = this.dataset.id;
            let image, name, price, quantity;
            $('.basket-image').each(function () {
                if (this.dataset.id == id) {
                    image = this.attributes[1].value;
                }
            });

            $('.card-title').each(function () {
                if (this.dataset.id == id) {
                    name = this.innerText;
                }
            });

            $('.price-basket').each(function () {
                if (this.dataset.id == id) {
                    price = this.dataset.price;
                }
            });

            $('.prod-cart-quantity').each(function () {
                if (this.dataset.id == id) {
                    quantity = Number(this.value);
                }
            });
            let prod = {
                id: id,
                name: name,
                image: image,
                price: price,
                quantity: quantity
            };
            prods.push(prod);
        });

        $.post([
            location.origin,
            'Order',
            'NewOrder'
        ].join('/'),
            {
                products: prods
            },
            () => {
                document.location.href = [location.origin, 'Order', 'NewOrder'].join('/');
            }
        )
    });

    $('.page-item').each(function () {
        this.onclick = function () {
            $('.active').removeClass('active');
            this.classList.add('active');
        };
    });

    $('.carousel-control-prev')[0].onclick = function () {
        let active = $('.active')[0];
        if (active.previousElementSibling != null) {
            active.classList.remove('active');
            active.previousElementSibling.classList.add('active');
        }
    };

    $('.carousel-control-next')[0].onclick = function () {
        let active = $('.active')[0];
        if (active.nextElementSibling != null) {
            active.classList.remove('active');
            active.nextElementSibling.classList.add('active');
        }
    };

    
});