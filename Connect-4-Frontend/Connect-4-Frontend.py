import pygame

# Initialize Pygame
pygame.init()

# Define grid dimensions
grid_width = 7
grid_height = 6

# Define cell size
cell_size = 50

# Calculate window size based on grid dimensions and cell size
window_width = grid_width * cell_size
window_height = grid_height * cell_size

# Create the game window
window = pygame.display.set_mode((window_width, window_height))

# Clear the window
window.fill((255, 255, 255))

# Set the window title
pygame.display.set_caption("Connect 4")
for x in range(grid_width):
        for y in range(grid_height):
            pygame.draw.rect(window, (0, 0, 1), (x * cell_size, y * cell_size, cell_size, cell_size), 1)

# Game loop
running = True
drawGrid = False
while running:
    # Handle events
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.MOUSEBUTTONDOWN:
            # Get the position of the mouse click
            mouse_pos = pygame.mouse.get_pos()
            # Calculate the grid position based on the mouse position and cell size
            grid_x = mouse_pos[0] // cell_size
            grid_y = mouse_pos[1] // cell_size
            
            # Draw a yellow circle centered in the clicked square
            circle_radius = (cell_size // 2) - 5
            circle_center_x = (grid_x * cell_size) + (cell_size // 2)
            circle_center_y = (grid_y * cell_size) + (cell_size // 2)
            pygame.draw.circle(window, (0, 0, 1), (circle_center_x, circle_center_y), circle_radius + 3)
            pygame.draw.circle(window, (255, 255, 1), (circle_center_x, circle_center_y), circle_radius)
            
            
            # Update the display
            pygame.display.flip()
            
            # Print the grid position to the console
            print(f"Tile clicked: ({grid_x}, {grid_y})")


    # Update the display
    pygame.display.flip()

# Quit Pygame
pygame.quit()