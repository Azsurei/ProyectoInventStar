/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lp2.cdejava.inventstar.inventario.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import lp2.cdejava.inventstar.config.DBManager;
import lp2.cdejava.inventstar.inventario.dao.ProveedorDAO;
import lp2.cdejava.inventstar.inventario.model.Contacto;
import lp2.cdejava.inventstar.inventario.model.Proveedor;

/**
 *
 * @author Lenovo
 */
public class ProveedorMySQL implements ProveedorDAO{

    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;

    public int insertarProveedor(Proveedor proveedor, Contacto contacto) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL INSERTAR_PROVEEDOR(?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_proveedor", java.sql.Types.INTEGER);
            cs.setString("_nombre",proveedor.getNombre());
            cs.setString("_RUCProveedor", proveedor.getRUC());
            cs.setString("_razon_socialProveedor", proveedor.getRazonSocial());
            cs.setString("_direccionProveedor", proveedor.getDireccion());
            cs.setString("_emailProveedor", proveedor.getEmail());
            cs.setString("_telefonoProveedor", proveedor.getTelefono());
            cs.executeUpdate();
            resultado = cs.getInt("_id_proveedor");
            System.out.println(resultado);
            cs = con.prepareCall("{call INSERTAR_CONTACTO(?,?,?,?,?,?,?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_idContacto", java.sql.Types.INTEGER);
            cs.setString("_nombresPersona", contacto.getNombres());
            cs.setString("_apellidoPatPersona", contacto.getApellidoPat());
            cs.setString("_apellidoMatPersona", contacto.getApellidoMat());
            cs.setString("_numDocumentoPersona", contacto.getNumDocumento());
            cs.setString("_telefono1Persona", contacto.getTelefono1());
            cs.setString("_telefono2Persona", contacto.getTelefono2());
            cs.setString("_emailPersona", contacto.getEmail());
            cs.setString("_domicilioPersona", contacto.getDomicilio());
            cs.setDate("_fechaRegistroPersona", new java.sql.Date(contacto.getFechaRegistro().getTime()));
            cs.setDate("_fechaNacimientoPersona", new java.sql.Date(contacto.getFechaCumpleanhos().getTime()));
            cs.setString("_puestoContacto", contacto.getPuesto());
            cs.setInt("_fid_proveedor", resultado);
            cs.executeUpdate();

            resultado = 1;
        } catch (Exception e) {
            System.out.println("Error al insertar proveedor: " + e.getMessage());
        } finally {
           try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }

    public ArrayList<Proveedor> listarProveedor() {
        ArrayList<Proveedor> lista = new ArrayList<>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL LISTAR_PROVEEDOR()}");
            rs = cs.executeQuery();
            while (rs.next()) {
                Proveedor proveedor = new Proveedor();
                proveedor.setIdProveedor(rs.getInt("id_proveedor"));
                proveedor.setNombre(rs.getString("nombre"));
                proveedor.setRUC(rs.getString("RUCProveedor"));
                proveedor.setRazonSocial(rs.getString("razon_socialProveedor"));
                proveedor.setDireccion(rs.getString("direccionProveedor"));
                proveedor.setEmail(rs.getString("emailProveedor"));
                proveedor.setTelefono(rs.getString("telefonoProveedor"));
                lista.add(proveedor);
            }
        } catch (Exception e) {
            System.out.println("Error al listar proveedor: " + e.getMessage());
        } finally {
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return lista;
    }

    public int modificarProveedor(Proveedor proveedor, Contacto contacto) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL MODIFICAR_PROVEEDOR(?,?,?,?,?,?,?)}");
            cs.setInt("_id_proveedor", proveedor.getIdProveedor());
            cs.setString("_nombre",proveedor.getNombre());
            cs.setString("_RUCProveedor", proveedor.getRUC());
            cs.setString("_razon_socialProveedor", proveedor.getRazonSocial());
            cs.setString("_direccionProveedor", proveedor.getDireccion());
            cs.setString("_emailProveedor", proveedor.getEmail());
            cs.setString("_telefonoProveedor", proveedor.getTelefono());
            cs.executeUpdate();
            cs = con.prepareCall("{call MODIFICAR_CONTACTO(?,?,?,?,?,?,?,?,?,?,?,?,?)}");
            cs.setInt("_idContacto", contacto.getIdPersona());
            cs.setString("_nombresPersona", contacto.getNombres());
            cs.setString("_apellidoPatPersona", contacto.getApellidoPat());
            cs.setString("_apellidoMatPersona", contacto.getApellidoMat());
            cs.setString("_numDocumentoPersona", contacto.getNumDocumento());
            cs.setString("_telefono1Persona", contacto.getTelefono1());
            cs.setString("_telefono2Persona", contacto.getTelefono2());
            cs.setString("_emailPersona", contacto.getEmail());
            cs.setString("_domicilioPersona", contacto.getDomicilio());
            cs.setDate("_fechaRegistroPersona", new java.sql.Date(contacto.getFechaRegistro().getTime()));
            cs.setDate("_fechaNacimientoPersona", new java.sql.Date(contacto.getFechaCumpleanhos().getTime()));
            cs.setString("_puestoContacto", contacto.getPuesto());
            cs.setInt("_fid_proveedor", proveedor.getIdProveedor());
            
            cs.executeUpdate();

            resultado = 1;
        } catch (Exception e) {
            System.out.println("Error al modificar proveedor: " + e.getMessage());
        } finally {
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }

    
    public int eliminarProveedor(int idProveedor) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL ELIMINAR_PROVEEDOR(?)}");
            cs.setInt("_id_proveedor", idProveedor);
            cs.executeUpdate();
            resultado = 1;
        } catch (Exception e) {
            System.out.println("Error al eliminar proveedor: " + e.getMessage());
        } finally {
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }
    
}
