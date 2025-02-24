using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task2.DataModel;
using Task2.Dto;
using Task2.Interfaces;

namespace Task2.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodolistService _todolistService;
        private readonly IMapper _mapper;
        public TodoController(ITodolistService todolistService, IMapper mapper)
        {
            _todolistService = todolistService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = _todolistService.Get();
            if (result == null) {
                return View("Error");
            }
           
            return View(_mapper.Map<IEnumerable<TodolistItemDto>>(result));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateTodolistItemDto createDto)
        {
            var newItem = _todolistService.Post(_mapper.Map<CreateTodolistItemDto, TodolistItem>(createDto));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var item = _todolistService.Get(id);
            if (item == null)
                return NotFound();
            return View(_mapper.Map<TodolistItem, TodolistItemDto>(item));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = _todolistService.Get(id);
            return View(_mapper.Map<TodolistItem,UpdateTodolistItemDto>(item));
        }

        public ActionResult Edit(UpdateTodolistItemDto updateDto)
        {
            var result = _todolistService.Put(_mapper.Map<UpdateTodolistItemDto, TodolistItem>(updateDto));
            return RedirectToAction("Index");
        }

        public ActionResult Delete([FromRoute]int id)
        {
            var result = _todolistService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
