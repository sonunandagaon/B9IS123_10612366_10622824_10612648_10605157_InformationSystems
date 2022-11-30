// Json Data

const products = [
    {
        id: "dumbell",
        name: "Dumbbell - Primal Strength",
        description: "The sizes 1kg to 30kg of the Primal Strength Rubber Hex Dumbbells are offered in pairs. The dumbbells have a lovely design that makes them both attractive in your gym and pleasant to use. To ensure optimal comfort, they have an easy-grip, ergonomic handle made of hardened chrome",
        rating: "★★★★☆",
        price: "€65",
        sale: "sale",
        image: [
            "images/Equipment_Images/Dumbell/H_D.jpg",
            "images/Equipment_Images/Dumbell/f1_D.jpg",
            "images/Equipment_Images/Dumbell/f3.3_D.jpg",
            "images/Equipment_Images/Dumbell/f2.2_D.jpg",
        ],
        video: "images/Equipment_Images/Dumbell/f4_video_D.mp4"

    },
    {
        id: "barbell",
        name: "Barbell - 20 kg",
        description: "Barbells come in different weights depending on the goals and requirements of the activity 20kg weightlifting bars. This is because end users find this bar most helpful because they may use it for a variety of popular gym routines. Given that, it is the bar that is most frequently utilized on the gym floor. Despite the fact that 20kg is frequently used, weightlifting bars can be weighed at 10kg, 15kg, or 20kg for Olympic competition. ",
        rating: "★★★★★",
        price: "€90",
        sale: "",
        image: [
            "images/Equipment_Images/Barbell/h.1_B.jpg",
            "images/Equipment_Images/Barbell/f2.1_B.jpg",
            "images/Equipment_Images/Barbell/f3.1_B.jpg",
            "images/Equipment_Images/Barbell/h.1_B.jpg",
        ],
        video: "images/Equipment_Images/Barbell/f4-video_B.mp4"

    },
    {
        id: "yogamat",
        name: "Yogamat (Pilates mat)",
        description: "With this great freebody exercise, an astute quality Yoga mat gives a feeling of relaxtion and stress reduction. Moreover, it is easy for cleaning and doing the maintainance this mat. Equip your gym with the highest quality products with this amazing pack of 10 yoga mats. These classic mats provide the budding yogi with the perfect base to hone their technique. Comfortable and functional, these mats ensure you practice your poses in a controlled area. Purchasing this package ensures continuity in the design of your gym while providing excellent value for money.",
        rating: "★★★★☆",
        price: "€15",
        sale: "sale",
        image: [
            "images/Equipment_Images/Yogamat/h_Y.jpg",
            "images/Equipment_Images/Yogamat/f1_Y.jpg",
            "images/Equipment_Images/Yogamat/f2.1_Y.jpg",
            "images/Equipment_Images/Yogamat/f3_Y.jpg",
        ],
        video: "images/Equipment_Images/Yogamat/f4_Y.mp4"
    },
    {
        id: "gymplates",
        name: "Loaded Gym Plates – Premium",
        description: "For an advanced muscle workout, plate loaded gym equipment from Injay offers unparalleled levels of safety and comfort, all while delivering impressive results. Plate loaded equipment such as selectorised curl and press machines are among the most effective strength building machines and perfectly complement strength workouts that require upper body training equipment. The Fitness Plate loaded Equipment is suitable for heavy commercial use and Home use.",
        rating: "★★★★☆",
        price: "€40",
        sale: "sale",
        image: [
            "images/Equipment_Images/Plates/h_P.jpg",
            "images/Equipment_Images/Plates/f1_P.jpg",
            "images/Equipment_Images/Plates/f3_P.jpg",
            "images/Equipment_Images/Plates/f3.1_P.jpg",
        ],
        video: "images/Equipment_Images/Plates/f4.mp4"
    },
    {
        id: "kettleBell",
        name: "Kettle Bell - Premium-Cast",
        description: "Most people agree that the Premium-Cast Kettlebells are the best premium-cast kettlebells currently on the market. The kettlebells are a need for any sports facility, gym, or CrossFit box, and their sturdy construction guarantees that they will last for years to come. These kettlebells have been expertly built using only premium-grade Iron Ore, not scrap iron (as with less expensive alternatives), and a one-piece cast mould guarantees the kettlebells' incredibly tough construction and flawless polish",
        rating: "★★★★☆",
        price: "€60",
        sale: "sale",
        image: [
            "images/Equipment_Images/Kettlebell/h.2_K.jpg",
            "images/Equipment_Images/Kettlebell/f1_k.jpg",
            "images/Equipment_Images/Kettlebell/h_K.jpg",
            "images/Equipment_Images/Kettlebell/f3.jpg",
        ],
        video: "images/Equipment_Images/Kettlebell/f4_K.mp4"
    },
    {
        id: "rowingMachine",
        name: "Rowing Machine",
        description: "Indoor rowing is the ideal form of training, suitable for any fitness level and any age, with regular use this machine will ensure you are fit and well throughout your life. Available to hire for the home and for commercial use. This robust piece of fitness equipment is low maintenance and easy to store or move around and comes with a digital monitor for accurate feedback, please note that we supply a PM5 or in some cases a PM3 monitor. If you need a specific monitor, please contact us after placing your order.",
        rating: "★★★★☆",
        price: "€50",
        sale: "sale",
        image: [
            "images/Equipment_Images/RowingMachine/h.1_RM.png",
            "images/Equipment_Images/RowingMachine/f1_RM.jpg",
            "images/Equipment_Images/RowingMachine/f2_RM.jpg",
            "images/Equipment_Images/RowingMachine/f3_RM.jpg",
        ],
        video: "images/Equipment_Images/RowingMachine/RM-video.mp4"
    },
    {
        id: "crossfitrope",
        name: "Cross Fit Rope",
        description: "The rope is made of 100% high-quality polyester.Most of the ropes available on the market are made of cheaper polypropylene or mixtures of derivatives, which results in less weight, worse flexibility and lower durability. It is the weight of the rope that directly affects the effectiveness of training, which is why this parameter should be taken into account when purchasing the ropes. The flexibility of the rope affects the comfort of training, high flexibility guarantees smooth operation of the rope during training and prevents it from twisting.",
        rating: "★★★★☆",
        price: "€75",
        sale: "",
        image: [
            "images/Equipment_Images/CrossfitRope/f1_R.jpg",
            "images/Equipment_Images/CrossfitRope/h1_R.jpg",
            "images/Equipment_Images/CrossfitRope/f2.jpg",
            "images/Equipment_Images/CrossfitRope/f3.2_R.jpg",
        ],
        video: "images/Equipment_Images/CrossfitRope/f4-video_R.mp4"
    },
    {
        id: "treadmills",
        name: "Treadmills",
        description: "The Run attack, curved treadmill is designed for natural human movement. It’s modern concave-shape makes it very similar to running outside as it allows you to run with a natural style. The treadmill is powered solely by your legs, not electricity. It has no top speed and with its curved, slatted running surface, runners create a momentum to turn the treadmill belt by using the balls of their feet",
        rating: "★★★★☆",
        price: "€125",
        sale: "sale",
        image: [
            "images/Equipment_Images/Trademill/f2.png",
            "images/Equipment_Images/Trademill/f1_T.png",
            "images/Equipment_Images/Trademill/f1.jpg",

            "images/Equipment_Images/Trademill/f3.1_RM.jpg",
        ],
        video: "images/Equipment_Images/Trademill/f3-video_T.mp4"
    },
]

//Display the details of the Products using JSON 

function allProducts() {
    a = document.getElementById("productGrid")
    let x = ""
    products.map((item, i) => {
        if (i === 0 || i === 5) {
            x = x + ` <div class="product-container" id="${item.name}" role="listitem">
            <div class="image-wrap">`+
                ` <div class="sale">
                    Sale
                </div>`+
                `<div 
                    style="background-image:url(${item.image[0]})"
                    class="product-image product-image-size-m">
                </div>
                <div class="view-product-container">
                                    <a style="opacity: 1;" class="view-button" onclick="productOnClick('${item.id}')">
                                        <div class="button-small white-small">
                                            <div>View Product</div>
                                        </div>
                                    </a>
                                </div>
            </div>
            <div class="product4-content-wrap"><a class="size6-link">${item.name}</a>
                <div 
                    class="size4-text">${item.price}</div>
            </div>
        </div>`
        }
        else {
            x = x + ` <div class="product-container" id="${item.name}" role="listitem">
            <div class="image-wrap">
            <div 
                    style="background-image:url(${item.image[0]})"
                    class="product-image product-image-size-m">
                </div>
                <div class="view-product-container">
                                    <a style="opacity: 1;" class="view-button" onclick="productOnClick('${item.id}')">
                                        <div class="button-small white-small">
                                            <div>View Product</div>
                                        </div>
                                    </a>
                                </div>
            </div>
            <div class="product4-content-wrap"><a class="size6-link">${item.name}</a>
                <div 
                    class="size4-text">${item.price}</div>
            </div>
        </div>`
        }
    })
    a.innerHTML = x
}

