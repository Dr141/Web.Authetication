using Identity.Application.DTOs.Request;
using Identity.Application.DTOs.Response;
using Identity.Application.Enums;
using Identity.Application.Interfaces.ServicesIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.Authen;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private IIdentityService _identity;
    public AuthenticationController(IIdentityService identity)
    => _identity = identity;

    [ProducesResponseType(typeof(UsuariosResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = nameof(Roles.Administrador))]
    [HttpGet("ObterTodos")]
    public async Task<ActionResult<UsuariosResponse>> ObterTodos()
    {
        var result = await _identity.ObterTodosUsuarios();
        return Ok(result);
    }

    [ProducesResponseType(typeof(UsuarioCadastroResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("Cadastro")]
    public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar(UsuarioCadastroRequest cadastroRequest)
    {
        if (ModelState.IsValid)
        {
            var result = await _identity.CadastrarUsuario(cadastroRequest);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result.Erros);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [ProducesResponseType(typeof(UsuarioLoginResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("Login")]
    public async Task<ActionResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin)
    {
        if (ModelState.IsValid) 
        {
            var result = await _identity.Login(usuarioLogin);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result.Erros);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [ProducesResponseType(typeof(UsuarioCadastroResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize]
    [HttpPut("AtualizarSenha")]
    public async Task<ActionResult<UsuarioCadastroResponse>> AtualizarSenha(UsuarioAtualizarSenhaResquest usuarioAtualizarSenha)
    {
        if (ModelState.IsValid)
        {
            var result = await _identity.AtualizarSenha(usuarioAtualizarSenha);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result.Erros);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [ProducesResponseType(typeof(UsuarioCadastroResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = nameof(Roles.Administrador))]
    [HttpPut("AtualizarSenhaInterno")]
    public async Task<ActionResult<UsuarioCadastroResponse>> AtualizarSenhaInterno(UsuarioCadastroRequest usuarioLoginAtualizarSenha)
    {
        if (ModelState.IsValid)
        {
            var result = await _identity.AtualizarSenhaInterno(usuarioLoginAtualizarSenha);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result.Erros);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [ProducesResponseType(typeof(UsuarioCadastroResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = nameof(Roles.Administrador))]
    [HttpPut("AtualizarPermissao")]
    public async Task<ActionResult<UsuarioCadastroResponse>> AtualizarPermissao(UsuarioAtualizarPermisaoRequest usuarioPermisao)
    {
        if (ModelState.IsValid)
        {
            var result = await _identity.AtualizarPermisao(usuarioPermisao);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result.Erros);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
