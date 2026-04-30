Shopping Cart System Program

Lawrence S. Frias   

BSIT 1-2

AI Usage:

I used AI to help me understand how to create an array that can access the fields in the Product class. It also taught me how to create an array of Product objects. 
I noticed that this is similar to a dictionary in Python. Next, I used AI to improve the formatting of my menu. I felt that my initial menu looked unpleasant, so it 
showed me how to align the text, although I'm still not very confident with it. So, I changed the formatting of my menu, receipt, and the updated stocks menu.

Prompts/questions I asked:
- "How to create an array that can access the fields of a class in C#?"
- "How to format my menu that looks like a table? (*pasted my initial menu)"

Changes I made after using AI:
- Learned how to create and use an array of Product objects
- Gained understanding of how object arrays are similar to dictionaries (conceptually)
- Improved data handling and organization in the program
- Enhanced formatting of the menu display
- Improved receipt layout and readability
- Improved updated stock display formatting
- Made the overall interface more clean and visually organized

Shopping Cart System Program Part 2

AI Usage:

I used AI to improve specific features in my program. First, I learned how to implement searching by category and product name without requiring exact spelling. This helped me understand how to use partial matching (such as using Contains with case-insensitive comparison), making the search feature more flexible and user-friendly.
Next, I used AI to learn how to access and display the current date and time in my receipt. This allowed me to fill the requirements and improve the overall functionality of the checkout system.
Lastly, I asked AI to review my program for possible major bugs. Through this, I became more aware of potential issues in my logic, especially in handling user input, cart operations, and stock updates.

Prompts/questions I asked:
- "How do I search through my product array (category) without the exact spelling of what I'm searching? (*provided my code)"
- "How do I print the date and time in C#?"
- "Is there any major bugs in my program? (*provided my code)"

Changes I made after using AI:
- Improved search functionality by enabling partial and case-insensitive matching for product name and category
- Added date and time display in the receipt to improve completeness and meet requirements
- Used AI feedback to identify and fix potential logic issues and bugs
- Improved handling of user input, cart operations, and stock updates
- Increased overall program stability and reliability

Part 2 Features
- Menu-driven system
  - Main menu with options (Add Products, Manage Cart, Search, Checkout)
- Add Products system
	- Add items to cart
	- Add quantity to item if already in cart
	- Validates product ID and quantity
	- Prevents adding beyond available stock
- Cart Management Menu
	- View cart contents
	- Remove specific item from cart
	- Update quantity (subtract item quantity)
	- Clear entire cart with confirmation
- Stock management improvements
	- Automatically deducts stock when adding to cart
	- Restores stock when removing or reducing cart items
- Search features
	- Search products by name (partial match allowed)
	- Search products by category (partial match allowed)
- Checkout system
	- Prevents checkout if cart is empty
	- Calculates grand total, discount, and final total
- Payment system
	- Accepts user payment input
	- Validates numeric input
	- Ensures payment is sufficient
	- Calculates and displays change
- Receipt system
	- Generates receipt number
	- Displays date and time
	- Shows itemized purchase (name, price, quantity, total)
	- Displays totals, discount, payment, and change
- Order history
	- Stores past transactions (final totals)
	- Displays list of previous final total
- Low stock alert
	- Warns when stock is <= 5
- Updated stock display
	- Shows remaining stock after checkout
- Looped shopping
	- Allows user to shop again without restarting program
- Improved Product class
	- Added category property
	- Added HasEnoughStock() method
	- Added DeductStock() method
- Enhanced input validation
	- Ensures correct input types (numbers, non-empty strings)
	- Prevents invalid operations across menus


