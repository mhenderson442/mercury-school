namespace MercurySchool.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReferenceDataController : ControllerBase
{
    private readonly IReferenceDataRepository _referenceDataRepository;

    public ReferenceDataController(IReferenceDataRepository referenceDataRepository) => _referenceDataRepository = referenceDataRepository;

    [HttpGet]
    [Route("{referencDataType}")]
    public async Task<IActionResult> GetAsync(string referencDataType)
    {
        try
        {
            var referenceDataList = await _referenceDataRepository.GetReferenceDataAsync(referencDataType);

            if (referenceDataList is null || referenceDataList.Count == 0)
            {
                return NotFound($"Unable to find data associated with {referencDataType}");
            }

            return Ok(referenceDataList);
        }
        catch (NullReferenceException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
