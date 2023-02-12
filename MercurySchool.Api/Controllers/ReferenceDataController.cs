namespace MercurySchool.Api.Controllers;

/// <summary>
/// Reference Data Controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class ReferenceDataController : ControllerBase
{
    private readonly IReferenceDataRepository _referenceDataRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="referenceDataRepository"><see cref="IReferenceDataRepository">Inject IReferenceDataRepository</see></param>
    public ReferenceDataController(IReferenceDataRepository referenceDataRepository) => _referenceDataRepository = referenceDataRepository;

    /// <summary>
    /// Get list of references by type
    /// </summary>
    /// <returns><see cref="IActionResult"></see></returns>
    /// <returns></returns>
    [HttpGet]
    [Route("{referenceDataType}")]
    public async Task<IActionResult> GetAsync(string referenceDataType)
    {
        try
        {
            var referenceDataList = await _referenceDataRepository.GetReferenceDataAsync(referenceDataType);

            if (referenceDataList is null || referenceDataList.Count == 0)
            {
                return NotFound($"Unable to find data associated with {referenceDataType}");
            }

            return Ok(referenceDataList);
        }
        catch (NullReferenceException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
