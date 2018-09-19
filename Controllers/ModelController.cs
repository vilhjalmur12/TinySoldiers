
[HttpGet("")]
public IActionResult GetAllModels() {
    return Ok("This is GetAllModels function");
}

[HttpGet("model/{modelId}")]
public IActionResult GetModelById(int modelId) {
    return Ok("This is model by id function");
}