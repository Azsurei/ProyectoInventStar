/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package lp2.cdejava.inventstar.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import lp2.cdejava.inventstar.inventario.dao.BebidaDAO;
import lp2.cdejava.inventstar.inventario.dao.ComidaDAO;
import lp2.cdejava.inventstar.inventario.dao.ContactoDAO;
import lp2.cdejava.inventstar.inventario.dao.IngredienteDAO;
import lp2.cdejava.inventstar.inventario.dao.InsumoPerecibleDAO;
import lp2.cdejava.inventstar.inventario.dao.MercanciaDAO;
import lp2.cdejava.inventstar.inventario.dao.MermaDAO;
import lp2.cdejava.inventstar.inventario.dao.OrdenCompraDAO;
import lp2.cdejava.inventstar.inventario.dao.ProveedorDAO;
import lp2.cdejava.inventstar.inventario.model.Bebida;
import lp2.cdejava.inventstar.inventario.model.Comida;
import lp2.cdejava.inventstar.inventario.model.Contacto;
import lp2.cdejava.inventstar.inventario.model.Ingrediente;
import lp2.cdejava.inventstar.inventario.model.InsumoPerecible;
import lp2.cdejava.inventstar.inventario.model.Mercancia;
import lp2.cdejava.inventstar.inventario.model.Merma;
import lp2.cdejava.inventstar.inventario.model.OrdenCompra;
import lp2.cdejava.inventstar.inventario.model.Proveedor;
import lp2.cdejava.inventstar.inventario.mysql.BebidaMySQL;
import lp2.cdejava.inventstar.inventario.mysql.ComidaMySQL;
import lp2.cdejava.inventstar.inventario.mysql.ContactoMySQL;
import lp2.cdejava.inventstar.inventario.mysql.IngredienteMySQL;
import lp2.cdejava.inventstar.inventario.mysql.InsumoPerecibleMySQL;
import lp2.cdejava.inventstar.inventario.mysql.MercanciaMySQL;
import lp2.cdejava.inventstar.inventario.mysql.MermaMySQL;
import lp2.cdejava.inventstar.inventario.mysql.OrdenCompraMySQL;
import lp2.cdejava.inventstar.inventario.mysql.ProveedorMySQL;


/**
 *
 * @author Usuario
 */
@WebService(serviceName = "InventarioWS")
public class InventarioWS {

    /**
     * This is a sample web service operation
     */
    private ComidaDAO daoComida = new ComidaMySQL();
    private BebidaDAO daoBebida = new BebidaMySQL();
    private MercanciaDAO daoMercancia = new MercanciaMySQL();
    private IngredienteDAO daoIngrediente = new IngredienteMySQL();
    private ProveedorDAO daoProveedor = new ProveedorMySQL();
    private OrdenCompraDAO daoOrdenCompra = new OrdenCompraMySQL();
    private InsumoPerecibleDAO daoInsumoPerecible = new InsumoPerecibleMySQL();
    private ContactoDAO daoContacto = new ContactoMySQL();
    private MermaDAO daoMerma = new MermaMySQL();
    
    @WebMethod(operationName = "insertarMerma")
    public int insertarMerma(@WebParam(name = "merma")Merma merma){
        int resultado = 0;
        try{
            resultado = daoMerma.insertarMerma(merma);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "modificarMerma")
    public int modificarMerma(@WebParam(name = "merma")Merma merma){
        int resultado = 0;
        try {
            resultado = daoMerma.modificarMerma(merma);
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "eliminarMerma")
    public int eliminarMerma(@WebParam(name = "idMerma")int idMerma){
        int resultado = 0;
        try {
            resultado = daoMerma.eliminarMerma(idMerma);
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "listarMerma")
    public ArrayList<Merma> listarMerma(){
        ArrayList<Merma> mermas = new ArrayList<>();
        try {
            mermas = daoMerma.listarMerma();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return mermas;
    }
    
    // Orden Compra
    @WebMethod(operationName = "listarOrdenCompras")
    public ArrayList<OrdenCompra> listarOrdenCompras() {
        ArrayList<OrdenCompra> ordenes = new ArrayList<>();
        try {
            ordenes = daoOrdenCompra.listarOrdenCompra();
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return ordenes;
    }
    
    @WebMethod(operationName = "listarOrdenCompraPorP")
    public ArrayList<OrdenCompra> listarOrdenCompraPorP(String nombre) {
        ArrayList<OrdenCompra> ordenes = new ArrayList<>();
        try {
            ordenes = daoOrdenCompra.listarOrdenCompraXNombreP(nombre);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return ordenes;
    }    
    
    @WebMethod(operationName = "listarOrdenCompraPorProveedor")
    public ArrayList<OrdenCompra> listarOrdenCompraPorProveedor(Proveedor _proveedor){
        ArrayList<OrdenCompra> ordenes = new ArrayList<>();
        try{
            ordenes = daoOrdenCompra.listarOrdenCompraPorProveedor(_proveedor);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return ordenes;
    }
    
    @WebMethod(operationName = "insertarOrdenCompra")
    public int insertarOrdenCompra(OrdenCompra ordenCompra){
        int resultado = 0;
        try {
            resultado = daoOrdenCompra.insertarOrdenCompra(ordenCompra);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
        
    @WebMethod(operationName = "eliminarOrdenCompra")
    public int eliminarOrdenCompra(int idOrdenCompra){
        int resultado = 0;
        try {
            resultado = daoOrdenCompra.eliminarOrdenCompra(idOrdenCompra);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    // Proveedor
    @WebMethod(operationName = "listarProveedor")
    public ArrayList<Proveedor> listarProveedor(){
        ArrayList<Proveedor> proveedores = new ArrayList<>();
        try{
            proveedores = daoProveedor.listarProveedor();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return proveedores;
    }
    
    @WebMethod(operationName = "modificarProveedor")
    public int modificarProveedor(Proveedor _proveedor, Contacto contacto){
        int resultado = 0;
        try{
            resultado = daoProveedor.modificarProveedor(_proveedor, contacto);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "insertarProveedor")
    public int insertarProveedor(Proveedor proveedor, Contacto contacto) {
        int resultado = 0;
        try {
            resultado = daoProveedor.insertarProveedor(proveedor, contacto);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "obtenerContactoPorIdProveedor")
    public Contacto obtenerContactoPorIdProveedor(int idProveedor){
        Contacto contacto = new Contacto();
        try{
            contacto = daoContacto.obtenerPorIdProveedor(idProveedor);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return contacto;
    }
    
    @WebMethod(operationName = "eliminarProveedor")
    public int eliminarProveedor(int idProveedor) {
        int resultado = 0;
        try {
            resultado = daoProveedor.eliminarProveedor(idProveedor);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    //Comida
    @WebMethod(operationName = "insertarComida")
    public int insertarComida(Comida comida) {
        int resultado = 0;
        try {
            resultado = daoComida.insertar(comida);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "modificarComida")
    public int modificarComida(Comida comida) {
        int resultado = 0;
        try {
            resultado = daoComida.modificar(comida);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "eliminarComida")
    public int eliminarComida(int idComida) {
        int resultado = 0;
        try {
            resultado = daoComida.eliminar(idComida);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "listarTodasComidas")
    public ArrayList<Comida> listarTodasComidas() {
        ArrayList<Comida> comidas = new ArrayList<>();
        try {
            comidas = daoComida.listarTodasComidas();
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return comidas;
    }
    
    @WebMethod(operationName = "listarComidasXNombre")
    public ArrayList<Comida> listarComidasXNombre(String nombre) {
        ArrayList<Comida> comidas = new ArrayList<>();
        try {
            comidas = daoComida.listarTodasComidasXNombre(nombre);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return comidas;
    }
    
    //Bebida
    @WebMethod(operationName = "insertarBebida")
    public int insertarBebida(Bebida bebida) {
        int resultado = 0;
        try {
            resultado = daoBebida.insertar(bebida);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "modificarBebida")
    public int modificarBebida(Bebida bebida) {
        int resultado = 0;
        try {
            resultado = daoBebida.modificar(bebida);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "eliminarBebida")
    public int eliminarBebida(int idBebida) {
        int resultado = 0;
        try {
            resultado = daoBebida.eliminar(idBebida);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "listarTodasBebidas")
    public ArrayList<Bebida> listarTodasBebidas() {
        ArrayList<Bebida> bebidas = new ArrayList<>();
        try {
            bebidas = daoBebida.listarTodasBebidas();
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return bebidas;
    }
    
    @WebMethod(operationName = "listarIngrediente")
    public ArrayList<Ingrediente> listarIngrediente() {
        ArrayList<Ingrediente> ingredientes = new ArrayList<>();
        try {
            ingredientes = daoIngrediente.listarIngrediente();
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return ingredientes;
    }
    
    @WebMethod(operationName = "listarIngredientesXNombre")
    public ArrayList<Ingrediente> listarIngredientesXNombre(String nombre) {
        ArrayList<Ingrediente> ingredientes = new ArrayList<>();
        try {
            ingredientes = daoIngrediente.listarIngredienteXNombre(nombre);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return ingredientes;
    }    
    
    @WebMethod(operationName = "listarMercancia")
    public ArrayList<Mercancia> listarMercancia() {
        ArrayList<Mercancia> mercancias = new ArrayList<>();
        try {
            mercancias = daoMercancia.listarTodasMercancias();
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return mercancias;
    }
    
    @WebMethod(operationName = "insertarInsumoPerecible")
    public int insertarInsumoPerecible(InsumoPerecible insumo) {
        int resultado = 0;
        try {
            resultado = daoInsumoPerecible.insertar(insumo);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }    
    
    @WebMethod(operationName = "listarTodosInsumos")
    public ArrayList<InsumoPerecible> listarTodosInsumos() {
        ArrayList<InsumoPerecible> insumos = new ArrayList<>();
        try {
            insumos = daoInsumoPerecible.listarInsumos();
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return insumos;
    }
    
    @WebMethod(operationName = "listarTodosInsumosXNombre")
    public ArrayList<InsumoPerecible> listarTodosInsumosXNombre(String nombre) {
        ArrayList<InsumoPerecible> insumos = new ArrayList<>();
        try {
            insumos = daoInsumoPerecible.listarInsumosXNombre(nombre);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return insumos;
    }
    
    @WebMethod(operationName = "modificarInsumoPerecible")
    public int modificarInsumoPerecible(InsumoPerecible insumo) {
        int resultado = 0;
        try {
            resultado = daoInsumoPerecible.modificarInsumo(insumo);
        }catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "listarLotes")
    public ArrayList<InsumoPerecible> listar(){
        ArrayList<InsumoPerecible> insumos = new ArrayList<>();
        try {
            insumos = daoInsumoPerecible.listar();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return insumos;
    }
}
