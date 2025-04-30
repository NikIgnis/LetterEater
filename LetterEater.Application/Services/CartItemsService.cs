using LetterEater.Core.Models;
using LetterEater.DataAccess.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Application.Services
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemsService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Guid> CreateCartItem(CartItem cartItem)
        {
            return await _cartItemRepository.Create(cartItem);
        }

        public async Task<List<CartItem>> GetAllCartItems()
        {
            return await _cartItemRepository.Get();
        }

        public async Task<Guid> UpdateCartItem(Guid cartItemId, Guid userId, Guid bookId, Book book, int quantity, decimal price)
        {
            return await _cartItemRepository.Update(cartItemId, userId, bookId, book, quantity, price);
        }

        public async Task<Guid> DeleteAllCartItems(Guid catItemId)
        {
            return await _cartItemRepository.Delete(catItemId);
        }
    }
}
